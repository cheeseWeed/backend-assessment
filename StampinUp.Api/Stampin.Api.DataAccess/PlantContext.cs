using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stampin.Api.Common;

namespace Stampin.Api.DataAccess
{
  /// <summary>
  /// Plantcontext data access class
  /// </summary>
  public class PlantContext : DbContext, IPlantContext
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<PlantContext> Logger;

    /// <summary>
    /// Plantcontext constructor
    /// </summary>
    public PlantContext(ILogger<PlantContext> logger, DbContextOptions<PlantContext> options) 
      : base(options)
    {
      Logger = logger;
    }

    /// <summary>
    /// Tree dbSet
    /// </summary>
    public DbSet<Tree> TreeX { get; set; }

    /// <summary>
    /// weed dbset
    /// </summary>
    public DbSet<Weed> WeedX { get; set; }

    /// <inheritdoc />
    public Success UpsertTree(List<Tree> request)
    {
      try
      {
        foreach (var tree in request)
        {
          var item = this.TreeX.FirstOrDefault(x => x.Id == tree.Id);
          bool create = item == null;
          item ??= new Tree();
          item.Id = tree.Id;
          item.Name = tree.Name;
          item.FallColor = tree.FallColor;
          item.Conifer = tree.Conifer;
          item.Deciduous = tree.Deciduous;
          item.SpringFlowers = tree.SpringFlowers;
          item.Width = tree.Width;
          item.Height = tree.Height;
          if (create)
          {
            this.TreeX.Add(item);
          }
        }

        this.SaveChanges();
        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to upsert Tree");
        return new Success
        {
          Msg = $"unable to upsert Tree: {JsonConvert.SerializeObject(request)}",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Success UpsertWeed(List<Weed> request)
    {
      try
      {
        foreach (var weed in request)
        {
          var item = this.WeedX.FirstOrDefault(x => x.Id == weed.Id);
          bool create = item == null;
          item ??= new Weed();
          item.Id = weed.Id;
          item.Name = weed.Name;
          item.FlowerColor = weed.FlowerColor;
          item.OverallColor = weed.OverallColor;
          item.Thorns = weed.Thorns;
          item.Width = weed.Width;
          item.Height = weed.Height;
          if (create)
          {
            this.WeedX.Add(item);
          }
        }

        this.SaveChanges();
        return new Success
        {
          Successfull = true
        };

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to upsert weed");
        return new Success
        {
          Msg = $"unable to upsert Weed: {JsonConvert.SerializeObject(request)}",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Success DeleteWeed(int id)
    {
      try
      {
        var item = this.WeedX.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
          item = null;
          this.SaveChanges();
        }

        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete weed");
        return new Success
        {
          Msg = $"unable to Delete Weed: {id}",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Success DeleteTree(int id)
    {
      try
      {
        var item = this.TreeX.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
          item = null;
          this.SaveChanges();
        }

        return new Success
        {
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete tree");
        return new Success
        {
          Msg = $"unable to Delete Tree: {id}",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<Tree> GetTreesById(int id)
    {
      try
      {
        return new Response<Tree>
        {
          Values = this.TreeX.FirstOrDefault(x => x.Id == id),
          Successfull = true
        };

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get tree");
        return new Response<Tree>
        {
          Msg = "Unable to get tree",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Tree>> GetTreesByName(string name)
    {
      try
      {
        return new Response<List<Tree>>
        {
          Values = this.TreeX.Where(x => x.Name.Contains(name)).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get tree by name");
        return new Response<List<Tree>>
        {
          Msg = "Unable to get tree by name",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Tree>> GetTreesWithFallColor()
    {
      try
      {
        return new Response<List<Tree>>
        {
          Values = this.TreeX.Where(x => x.FallColor != Color.None).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get tree with fall color");
        return new Response<List<Tree>>
        {
          Msg = "Unable to get tree with fall color",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Tree>> GetTreesWithSpringFlowers()
    {
      try
      {
        return new Response<List<Tree>>
        {
          Values = this.TreeX.Where(x => x.SpringFlowers).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get tree with flowers");
        return new Response<List<Tree>>
        {
          Msg = "Unable to get tree with spring flowers",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Tree>> GetConiferisTrees()
    {
      try
      {
        return new Response<List<Tree>>
        {
          Values = this.TreeX.Where(x => x.Conifer).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get conifer trees");
        return new Response<List<Tree>>
        {
          Msg = "Unable to get conifer tree ",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Tree>> GetDeciduousTrees()
    {
      try
      {
        return new Response<List<Tree>>
        {
          Values = this.TreeX.Where(x => x.Deciduous).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get deciduous trees");
        return new Response<List<Tree>>
        {
          Msg = "Unable to get deciduous trees",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<Weed> GetweedById(int id)
    {
      try
      {
        return new Response<Weed>
        {
          Values = this.WeedX.FirstOrDefault(x => x.Id == id),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get weed by id");
        return new Response<Weed>
        {
          Msg = "Unable to get  weed by id",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Weed>> GetWeedsByName(string name)
    {
      try
      {
        return new Response<List<Weed>>
        {
          Values = this.WeedX.Where(x => x.Name.Contains(name)).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get weeds by name");
        return new Response<List<Weed>>
        {
          Msg = "Unable to get  weed by name",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Weed>> GetWeedsWithFlowerColor()
    {
      try
      {
        return new Response<List<Weed>>
        {
          Values = this.WeedX.Where(x => x.FlowerColor != Color.None).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get weeds with flowers");
        return new Response<List<Weed>>
        {
          Msg = "Unable to get weeds with flowers",
          Successfull = false
        };
      }
    }

    /// <inheritdoc />
    public Response<List<Weed>> GetWeedsWithThorns()
    {
      try
      {
        return new Response<List<Weed>>
        {
          Values = this.WeedX.Where(x => x.Thorns).ToList(),
          Successfull = true
        };
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to get weeds with thorns");
        return new Response<List<Weed>>
        {
          Msg = "Unable to get weeds with thorns",
          Successfull = false
        };
      }
    }
  }
}
