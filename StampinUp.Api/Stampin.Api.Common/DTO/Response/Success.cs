using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// success class
  /// </summary>
  public class Success
  {
    /// <summary>
    /// is successfull
    /// </summary>
    public bool Successfull { get; set; }

    /// <summary>
    /// error message
    /// </summary>
    public string Msg { get; set; }
  }
}
