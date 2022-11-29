using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// update weeds request
  /// </summary>
  public class UpdateWeedsRequest
  {
    /// <summary>
    /// list of weeds to update
    /// </summary>
    public List<Weed> Weeds { get; set; }
  }
}
