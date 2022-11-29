using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// tree object
  /// </summary>
  public class Tree : Plant
  {
    /// <summary>
    /// is deciduous
    /// </summary>
    public bool Deciduous { get; set; }

    /// <summary>
    /// is a conifer
    /// </summary>
    public bool Conifer { get; set; }

    /// <summary>
    /// fall color
    /// </summary>
    public Color  FallColor { get; set; }

    /// <summary>
    /// has spring flowers
    /// </summary>
    public bool SpringFlowers { get; set; }
  }
}
