using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
  internal class CollectionHandlerEventArgs:EventArgs
  {
    public int? Index { get; set; }
    public string? Status { get; set; }
    public object? Object { get; set; }

    public CollectionHandlerEventArgs(int? number = null, string? status = null, object? obj = null)
    {
      Index = number;
      Status = status;
      Object = obj;
    }
  }
}
