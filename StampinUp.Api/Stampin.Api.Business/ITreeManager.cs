using Stampin.Api.Common;

namespace Stampin.Api.Business
{
  public interface ITreeManager
  {
    /// <summary>
    /// Gets the tree records
    /// </summary>
    /// <param name="value">values to get off of</param>
    /// <returns>Get tree response</returns>
    public GetTreesResponse GetTrees(string value);

    /// <summary>
    /// Updates the tree record
    /// </summary>
    /// <param name="request">Update Trees Request</param>
    /// <returns>Update Trees Response</returns>
    public UpdateTreesResponse UpdateTrees(UpdateTreesRequest request);

    /// <summary>
    /// Create the tree record
    /// </summary>
    /// <param name="request">Create Trees Request</param>
    /// <returns>Create Trees Response</returns>
    public CreateTreesResponse CreateTrees(CreateTreesRequest request);

    /// <summary>
    /// Delete the tree record
    /// </summary>
    /// <param name="request">Delete Trees Request</param>
    /// <returns>Delete Trees Response</returns>
    public DeleteTreesResponse DeleteTrees(DeleteTreeRequest request);
  }
}
