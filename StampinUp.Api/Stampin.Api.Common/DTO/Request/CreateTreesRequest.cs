using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// create tree request
  /// </summary>
  public class CreateTreesRequest
  {
    /// <summary>
    /// list of trees to create
    /// </summary>
    public List<Tree> Trees { get; set; }
  }
}
