using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_13
{
  internal class Journal
  {
    List<string> journal = new List<string>();
   // List<object?> Nodes = new List<object?>();
    public bool IsDetailed { get; set; }


    public void WriteRecord(object source, CollectionHandlerEventArgs e)
    {
      if (e.Status == "Был добавлен" || e.Status == "Был удалён")
        journal.Add($"{e.Status} элемент {e.Object}, позиция {e.Index + 1}.");
      else
        journal.Add(e.Status);
      //Nodes.Add(e.Object);
    }

    public void PrintJournal()
    {
      if (journal.Count != 0)
        for (int i = 0; i < journal.Count; i++)
          Console.WriteLine(journal[i]);
      else
        Console.WriteLine("Журнал пуст");
    }

    public void Reset()
    {
      journal = new List<string>();
    }

    public Journal() { }
  }
}
