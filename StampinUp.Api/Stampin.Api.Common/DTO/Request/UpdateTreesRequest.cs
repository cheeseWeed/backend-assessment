using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// update tree request
  /// </summary>
  public class UpdateTreesRequest
  {
    /// <summary>
    /// list of trees to update
    /// </summary>
    public List<Tree> Trees { get; set; }
  }
}
