using Lab_10;
using static Lab_10.Logic;
using lab_12;
using lab_13;

namespace Демонстрация
{
  internal class Program
  {
    static void Main(string[] args)
    {
      MyObservableCollection<Watch> obs1 = new MyObservableCollection<Watch>();
      MyObservableCollection<Watch> obs2 = new MyObservableCollection<Watch>();

      Journal journal1 = new Journal();
      obs1.CollectionCountChanged += journal1.WriteRecord;
      Journal journal2 = new Journal();
      obs1.CollectionReferenceChanged += journal2.WriteRecord;
      obs2.CollectionReferenceChanged += journal2.WriteRecord;


      obs1.Insert(0, new Watch(), "#1");
      obs1[0].RandomInit();
      obs1.Insert(0, new Watch(), "#1");
      obs1[0].RandomInit();
      obs1.Insert(0, new Watch(), "#1");
      obs1[0].RandomInit();
      obs2.Insert(0, new Watch(), "#2");
      obs2[0].RandomInit();
      obs2.Insert(0, new Watch(), "#2");
      obs2[0].RandomInit();
      obs2.Insert(0, new Watch(), "#2");
      obs2[0].RandomInit();
      obs2.Insert(0, new Watch(), "#2");
      obs2[0].RandomInit();

      Console.WriteLine($"#1\n{obs1}\n#2\n{obs2}\n");


      obs2.RemoveAt(2, "#2");

      obs1.RemoveAt(1, "#1");
      
      obs1.Replace(1, new SmartWatch(), "#1");

      obs2.Replace(0, new SmartWatch(), "#2");

      Console.WriteLine($"После изменений:\n#1\n{obs1}\n#2\n{obs2}\n");

      journal1.PrintJournal();
      journal2.PrintJournal();
    }
  }
}