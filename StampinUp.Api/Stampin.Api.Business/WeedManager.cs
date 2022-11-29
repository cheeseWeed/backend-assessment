using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stampin.Api.Common;
using Stampin.Api.DataAccess;

namespace Stampin.Api.Business
{
  public class WeedManager : IWeedManager
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<WeedManager> Logger;

    /// <summary>
    /// the weed manager
    /// </summary>
    private readonly IPlantContext PlantContext;

    public WeedManager(ILogger<WeedManager> logger, IPlantContext plantc)
    {
      this.PlantContext = plantc;
    }
    public WeedManager(ILogger<WeedManager> logger, IServiceProvider serviceProvider)
    {
      this.Logger = logger;
      this.PlantContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<PlantContext>();
    }

    /// <inheritdoc />
    public CreateWeedsResponse CreateWeeds(CreateWeedsRequest request)
    {
      CreateWeedsResponse response = new CreateWeedsResponse();
      try
      {
        if (request?.Weeds != null)
        {
          response.Success = this.PlantContext.UpsertWeed(request.Weeds);
        }
        else
        {
          response.Success = new Success
          {
            Msg = "unable to update weeds",
            Successfull = false
          };
        }

      }
      catch (Exception)
      {
        new CreateWeedsResponse
        {
          Success = new Success
          {
            Msg = "There was an error updating weeds",
            Successfull = false
          }
        };
      }

      return response;
    }

    /// <inheritdoc />
    public DeleteWeedsResponse DeleteWeeds(DeleteWeedsRequest request)
    {
      DeleteWeedsResponse response = new DeleteWeedsResponse();
      if (request != null)
      {
        response.Success = this.PlantContext.DeleteWeed(request.Id);
      }

      return response;
    }

    /// <inheritdoc />
    public GetWeedsResponse GetWeeds(string value)
    {
      GetWeedsResponse weedResponse = new GetWeedsResponse { Weeds = new Dictionary<string, List<Weed>>(), Success = new Success() };
      try
      {
        bool failed = false;
        string[] pairs = value?.Split('&');
        Dictionary<string, string> arguments = new Dictionary<string, string>();
        foreach (var pair in pairs ?? new string[0])
        {
          var set = pair.Split("=");
          if (set.Count() != 2)
          {
            return new GetWeedsResponse
            {
              Success = new Success
              {
                Successfull = false,
                Msg = "Unable to parse input string"
              }
            };
          }

          arguments.Add(set[0], set[1]);
        }

        foreach (var item in arguments)
        {
          switch (item.Key)
          {
            case "Id":
              {
                bool valid = int.TryParse(item.Value, out int result);
                if (valid)
                {
                  var ids = this.PlantContext.GetweedById(result);
                  if (ids != null && ids.Successfull && ids.Values != null)
                  {
                    weedResponse.Weeds.Add(item.Key, new List<Weed> { ids.Values });
                  }
                  else
                  {
                    failed = true;
                  }
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "Name":
              {
                var names = this.PlantContext.GetWeedsByName(item.Value);
                if (names != null && names.Successfull && names.Values != null)
                {
                  weedResponse.Weeds.Add(item.Key, names.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "FlowerColor":
              {
                if (item.Value == "false")
                {
                  break;
                }

                var color = this.PlantContext.GetWeedsWithFlowerColor();
                if (color != null && color.Successfull && color.Values != null)
                {
                  weedResponse.Weeds.Add(item.Key, color.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            case "Thorns":
              {
                if (item.Value == "false")
                {
                  break;
                }

                var thorns = this.PlantContext.GetWeedsWithThorns();
                if (thorns != null && thorns.Successfull && thorns.Values != null)
                {
                  weedResponse.Weeds.Add(item.Key, thorns.Values);
                }
                else
                {
                  failed = true;
                }
                break;
              }
            default:
              {
                failed = true;
                break;
              }
          }
        }
        weedResponse.Success.Successfull = !failed;
        return weedResponse;
      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unsuccessfull in getting weeds");
        weedResponse.Success.Msg = "Unsuccessfull in getting weeds";
        return weedResponse;
      }
    }

    /// <inheritdoc />
    public UpdateWeedsResponse UpdateWeeds(UpdateWeedsRequest request)
    {
      UpdateWeedsResponse response = new UpdateWeedsResponse();
      try
      {
        if (request?.Weeds != null)
        {
          response.Success = this.PlantContext.UpsertWeed(request.Weeds);
        }
        else
        {
          response.Success = new Success
          {
            Msg = "unable to update weeds",
            Successfull = false
          };
        }

      }
      catch (Exception)
      {
        new UpdateWeedsResponse
        {
          Success = new Success
          {
            Msg = "There was an error updating weeds",
            Successfull = false
          }
        };
      }

      return response;
    }
  }
}
