using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stampin.Api.Common;

namespace Stampin.Api.Business
{
  public interface IWeedManager
  {
    /// <summary>
    /// Gets the weed records
    /// </summary>
    /// <param name="value">values to get off of</param>
    /// <returns>Get weed response</returns>
    public GetWeedsResponse GetWeeds(string value);

    /// <summary>
    /// Updates the weed record
    /// </summary>
    /// <param name="request">Update weed Request</param>
    /// <returns>Update weed Response</returns>
    public UpdateWeedsResponse UpdateWeeds(UpdateWeedsRequest request);

    /// <summary>
    /// Create the weed record
    /// </summary>
    /// <param name="request">Create weed Request</param>
    /// <returns>Create weed Response</returns>
    public CreateWeedsResponse CreateWeeds(CreateWeedsRequest request);

    /// <summary>
    /// Delete the weed record
    /// </summary>
    /// <param name="request">Delete weed Request</param>
    /// <returns>Delete weed Response</returns>
    public DeleteWeedsResponse DeleteWeeds(DeleteWeedsRequest request);
  }
}
