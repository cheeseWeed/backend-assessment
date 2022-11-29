using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Stampin.Api.Common
{
  /// <summary>
  /// plant object
  /// </summary>
  public class Plant
  {
    /// <summary>
    /// string id
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    /// <summary>
    /// the name
    /// </summary>
    public string Name { get; set; }

    //string height
    public string Height { get; set; }

    /// <summary>
    /// string width
    /// </summary>
    public string Width { get; set; }
  }
}
