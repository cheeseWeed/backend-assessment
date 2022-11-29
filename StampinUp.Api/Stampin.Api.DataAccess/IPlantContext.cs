using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stampin.Api.Common;

namespace Stampin.Api.DataAccess
{
  /// <summary>
  /// plant context interface
  /// </summary>
  public interface IPlantContext
  {
    /// <summary>
    /// inserts or updates a tree record
    /// </summary>
    /// <param name="request">Tree request</param>
    /// <returns>success value</returns>
    public Success UpsertTree(List<Tree> request);


    /// <summary>
    /// inserts or updates a weed record
    /// </summary>
    /// <param name="request">Weed request</param>
    /// <returns>success value</returns>
    public Success UpsertWeed(List<Weed> request);

    /// <summary>
    /// Deletes a weed record
    /// </summary>
    /// <param name="request">Weed id</param>
    /// <returns>success value</returns>
    public Success DeleteWeed(int id);


    /// <summary>
    /// Deletes a tree record
    /// </summary>
    /// <param name="request">tree id</param>
    /// <returns>success value</returns>
    public Success DeleteTree(int id);

    /// <summary>
    /// Gets a Tree record
    /// </summary>
    /// <param name="request">Tree id</param>
    /// <returns>response of Tree record</return>
    public Response<Tree> GetTreesById(int id);

    /// <summary>
    /// Gets a weed record
    /// </summary>
    /// <param name="request">Weed id</param>
    /// <returns>response of weed record</returns>
    public Response<Weed> GetweedById(int id);

   /// <summary>
   /// Gets trees by name
   /// </summary>
   /// <param name="name">name</param>
   /// <returns>response of tree records</returns>
    public Response<List<Tree>> GetTreesByName(string name);

    /// <summary>
    /// Gets trees with fall color
    /// </summary>
    /// <returns>response of tree records</returns>
    public Response<List<Tree>> GetTreesWithFallColor();

    /// <summary>
    /// Gets trees with spring flowers
    /// </summary>
    /// <returns>response of tree records</returns>
    public Response<List<Tree>> GetTreesWithSpringFlowers();

    /// <summary>
    /// Gets conifer trees
    /// </summary>
    /// <returns>response of tree records</returns>
    public Response<List<Tree>> GetConiferisTrees();

    /// <summary>
    /// Gets deciduous trees
    /// </summary>
    /// <returns>tree records</returns>
    public Response<List<Tree>> GetDeciduousTrees();

    /// <summary>
    /// Gets weeds by name
    /// </summary>
    /// <param name="name">name</param>
    /// <returns>response of Weed records</returns>
    public Response<List<Weed>> GetWeedsByName(string name);

    /// <summary>
    /// Gets weeds with flowers
    /// </summary>
    /// <returns>response of Weed records</returns>
    public Response<List<Weed>> GetWeedsWithFlowerColor();

    /// <summary>
    /// gets weeds with thorns
    /// </summary>
    /// <returns>response of Weed records</returns>
    public Response<List<Weed>> GetWeedsWithThorns();
  }
}