using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// get weed request
  /// </summary>
  public class GetWeedsRequest
  {
    /// <summary>
    /// get by id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// get by name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// get by thorns
    /// </summary>
    public bool Thorns { get; set; }

    /// <summary>
    /// get by flower color
    /// </summary>
    public Color FlowerColor { get; set; }
  }
}
