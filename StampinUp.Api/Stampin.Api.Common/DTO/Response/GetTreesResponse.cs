using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// get tree request
  /// </summary>
  public class GetTreesResponse
  {
    /// <summary>
    /// success value
    /// </summary>
    public Success Success { get; set; }

    /// <summary>
    /// sets of trees recieved
    /// </summary>
    public Dictionary<string,List<Tree>> Trees { get; set; }
  }
}
