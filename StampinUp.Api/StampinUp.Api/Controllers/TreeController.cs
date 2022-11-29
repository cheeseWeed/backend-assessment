using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stampin.Api.Business;
using Stampin.Api.Common;

namespace StampinUp.Api.Controllers
{
  /// <summary>
  /// Tree Controller api 
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class TreeController : Controller
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<TreeController> Logger;

    /// <summary>
    /// the tree manager
    /// </summary>
    private readonly ITreeManager TreeManager;

    /// <summary>
    /// The Tree constructor
    /// </summary>
    /// <param name="logger">the logger</param>
    /// <param name="treeManager">the tree manager Interface</param>
    public TreeController(ILogger<TreeController> logger, ITreeManager treeManager)
    {
      this.Logger = logger;
      this.TreeManager = treeManager;
    }

    /// <summary>
    /// Gets a tree record
    /// </summary>
    /// <param name="value">records to get</param>
    /// <returns>Get Trees Response</returns>
    [HttpGet("GetTrees{value}")]
    public ActionResult<GetTreesResponse> GetTrees(string value)
    {
      try
      {
        GetTreesResponse response = this.TreeManager.GetTrees(value);
        if (response != null)
        {
          return response;
        }

        return base.NotFound("No records exist.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to Get Trees");
        return BadRequest("There was an error while retrieving records.");
      }
    }

    /// <summary>
    /// Creates a tree record
    /// </summary>
    /// <param name="request">GetTreesRequest</param>
    /// <returns>Create Trees Response</returns>
    [HttpPost("CreateTrees")]
    public ActionResult<CreateTreesResponse> CreateTrees(CreateTreesRequest request)
    {
      try
      {
        CreateTreesResponse response = this.TreeManager.CreateTrees(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Could not add record");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to create trees");
        return BadRequest("There was an error while creating records.");
      }
    }

    /// <summary>
    /// Updates the tree record
    /// </summary>
    /// <param name="request">Update Trees Request</param>
    /// <returns>Update Trees Response</returns>
    [HttpPut("UpdateTrees")]
    public ActionResult<UpdateTreesResponse> UpdateTrees(UpdateTreesRequest request)
    {
      try
      {
        UpdateTreesResponse response = this.TreeManager.UpdateTrees(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Unable to update record.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to update trees");
        return BadRequest("There was an error while updating records.");
      }
    }

    /// <summary>
    /// Deletes the record
    /// </summary>
    /// <param name="request">Delete Tree Request</param>
    /// <returns>Delete Trees Response</returns>
    [HttpDelete("DeleteTrees")]
    public ActionResult<DeleteTreesResponse> DeleteTrees(DeleteTreeRequest request)
    {
      try
      {
        DeleteTreesResponse response = this.TreeManager.DeleteTrees(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Unable to delete record.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete trees");
        return BadRequest("There was an error while deleting records.");
      }
    }
  }
}
