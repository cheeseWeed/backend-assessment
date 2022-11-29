using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stampin.Api.Common
{
  /// <summary>
  /// response object
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Response<T> : Success
  {
    /// <summary>
    /// respnse values
    /// </summary>
    public T Values { get; set; }
  }
}
