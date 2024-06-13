using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
  internal class CollectionHandlerEventArgs:EventArgs
  {
    public int Number { get; set; }
    public int Status { get; set; }
    public object Object { get; set; }
  }
}
