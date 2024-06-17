using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
  public class CollectionHandlerEventArgs:EventArgs
  {
    public int? Index { get; set; }
    public string? Status { get; set; }
    public object? Object { get; set; }
    public string CollName { get; set; }

    public CollectionHandlerEventArgs(int? number = null, string? status = null, object? obj = null, string collName = null)
    {
      Index = number;
      Status = status;
      Object = obj;
      CollName = collName;
    }
  }
}
