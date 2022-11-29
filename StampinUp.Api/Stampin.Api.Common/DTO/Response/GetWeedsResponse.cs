using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// get weed response
  /// </summary>
  public class GetWeedsResponse
  {
    /// <summary>
    /// success value
    /// </summary>
    public Success Success { get; set; }

    /// <summary>
    /// sets of Weed recieved
    /// </summary>
    public Dictionary<string, List<Weed>> Weeds { get; set; }
  }
}
