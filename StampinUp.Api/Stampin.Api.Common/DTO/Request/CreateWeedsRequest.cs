using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// create weed request
  /// </summary>
  public class CreateWeedsRequest
  {
    /// <summary>
    /// list of weeds to create
    /// </summary>
    public List<Weed> Weeds { get; set; }
  }
}
