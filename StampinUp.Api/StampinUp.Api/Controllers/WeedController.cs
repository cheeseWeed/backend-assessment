using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stampin.Api.Business;
using Stampin.Api.Common;

namespace StampinUp.Api.Controllers
{
  /// <summary>
  /// Weed Controller api 
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class WeedController : Controller
  {
    /// <summary>
    /// the Logger
    /// </summary>
    private readonly ILogger<WeedController> Logger;

    /// <summary>
    /// the weed manager
    /// </summary>
    private readonly IWeedManager WeedManager;

    /// <summary>
    /// The Weed constructor
    /// </summary>
    /// <param name="logger">the logger</param>
    /// <param name="treeManager">the weed manager Interface</param>
    public WeedController(ILogger<WeedController> logger, IWeedManager weedManager)
    {
      this.Logger = logger;
      this.WeedManager = weedManager;
    }

    /// <summary>
    /// Gets a weed record
    /// </summary>
    /// <param name="value">records to get</param>
    /// <returns>Get Trees Response</returns>
    [HttpGet("GetWeeds{value}")]
    public ActionResult<GetWeedsResponse> GetWeeds(string value)
    {
      try
      {
        GetWeedsResponse response = this.WeedManager.GetWeeds(value);
        if (response != null)
        {
          return response;
        }

        return NotFound("No records exist.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to Get Weeds");
        return BadRequest("There was an error while retrieving records.");
      }
    }

    /// <summary>
    /// Creates a weed record
    /// </summary>
    /// <param name="request">GetWeedRequest</param>
    /// <returns>Create Trees Response</returns>
    [HttpPost("CreateWeeds")]
    public ActionResult<CreateWeedsResponse> CreateWeeds(CreateWeedsRequest request)
    {
      try
      {
        CreateWeedsResponse response = this.WeedManager.CreateWeeds(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Could not add record");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to create weeds");
        return BadRequest("There was an error while creating records.");
      }
    }

    /// <summary>
    /// Updates the weed record
    /// </summary>
    /// <param name="request">Update weed Request</param>
    /// <returns>Update weed Response</returns>
    [HttpPut("UpdateWeeds")]
    public ActionResult<UpdateWeedsResponse> UpdateWeeds(UpdateWeedsRequest request)
    {
      try
      {
        UpdateWeedsResponse response = this.WeedManager.UpdateWeeds(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Unable to update record.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to update weeds");
        return BadRequest("There was an error while updating records.");
      }
    }

    /// <summary>
    /// Deletes the record
    /// </summary>
    /// <param name="request">Delete weed Request</param>
    /// <returns>Delete weed Response</returns>
    [HttpDelete("DeleteWeeds")]
    public ActionResult<DeleteWeedsResponse> DeleteWeeds(DeleteWeedsRequest request)
    {
      try
      {
        DeleteWeedsResponse response = this.WeedManager.DeleteWeeds(request);
        if (response != null)
        {
          return response;
        }

        return NotFound("Unable to delete record.");

      }
      catch (Exception ex)
      {
        Logger.LogError(ex, "Unable to delete weeds");
        return BadRequest("There was an error while deleting records.");
      }
    }
  }
}