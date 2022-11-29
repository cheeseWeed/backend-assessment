namespace Stampin.Api.Common
{
  /// <summary>
  /// get tree request
  /// </summary>
  public class GetTreesRequest
  {
    /// <summary>
    /// tree id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// tree name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// tree deciduous
    /// </summary>
    public bool Deciduous { get; set; }

    /// <summary>
    /// is conifer
    /// </summary>
    public bool Conifer { get; set; }

    /// <summary>
    /// has fall color
    /// </summary>
    public bool FallColor { get; set; }

    /// <summary>
    /// spring flowers
    /// </summary>
    public bool SpringFlowers { get; set; }
  }
}
