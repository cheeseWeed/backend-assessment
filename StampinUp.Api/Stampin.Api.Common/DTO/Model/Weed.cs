namespace Stampin.Api.Common
{
  /// <summary>
  /// the weed object
  /// </summary>
  public class Weed : Plant
  {
    /// <summary>
    /// has thorns
    /// </summary>
    public bool Thorns { get; set; }

    /// <summary>
    /// flower color
    /// </summary>
    public Color FlowerColor { get; set; }

    /// <summary>
    /// overal color
    /// </summary>
    public Color OverallColor { get; set; }
  }
}
