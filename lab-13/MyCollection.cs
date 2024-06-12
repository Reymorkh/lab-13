using static Lab_10.Logic;
using Lab_10;

namespace lab_12
{
  public class MyCollection <T> where T: IBaseProperties, ICloneable, IInit, new()
  {

    int count = 0;

    public int Count {  get { return count; } }

    public Node<T>? First
    {
      get; set;
    }

    public Node<T>? Last
    {
      get; set;
    }

    public void CollectionReset()
    {
      if (count != 0)
      {
        Node<T> temp = First;
        while (temp.Next != null)
        {
          temp.Previous = null;
          if (temp.Next != null)
          {
            temp = temp.Next;
            temp.Previous.Next = null;
          }
        }
        temp.Previous = null;
        First = null;
        Last = null;
        count = 0;
      }
      else
        throw new Exception("Список и без того пуст.");
    }

    public MyCollection() { }

    object GetWatch(int temp) => temp == 1 ? new Watch() : temp == 2 ? new AnalogWatch() : temp == 3 ? new DigitalWatch() : new SmartWatch();

    public MyCollection(int length)
    {
      Random rnd = new Random();
      int rndResult = rnd.Next(1,4);
      First = new Node<T>(new T());
      Node<T> tempNode = First;
      First.Value.RandomInit();
      for (int i = 1; i < length; i++)
      {
        rndResult = rnd.Next(1, 4);
        Node<T> newNode = new Node<T>(new T());
        newNode.Value.RandomInit();
        tempNode.Next = newNode;
        newNode.Previous = tempNode;
        tempNode = newNode;
      }
      Last = tempNode;
    }

    public string ShowItems()
    {
      if (First == null)
        return "Коллекция пуста.";
      else
      {
        uint counter = 2;
        string output = "1. ";
        Node<T> current = First;
        while (current != null)
        {
          output += current.Value.ToString() + "\n" + (current.Next != null ? counter + ". " : "");
          current = current.Next;
          counter++;
        }
        return output == "1. " ? "Коллекция пуста." : output;
      }
    }

    public override string ToString() => ShowItems();

    //public DoublyLinkedList<T> Clone() => new DoublyLinkedList<T>(this);

    #region Добавление
    public void AddFirst(T item)
    {
      if (First == null)
      {
        First = new Node<T>(item);
        Last = First;
      }
      else
      {
        First.Previous = new Node<T>(item);
        First.Previous.Next = First;
        First = First.Previous;
      }
      count++;
    } //работает как часы

    public string Insert(T item, int index)
    {
      if (index > count - 1)
      {
        Add(item);
        if (index == count - 1)
          return "";
        else
          return "Вы ввели слишком большой номер элемента. Элемент был записан в конец.";
      }
      else if (index < 0)
      {
        AddFirst(item);
        return "Вы ввели слишком малый номер элемента. Элемент был записан в начало.";
      }
      else if (index == 0)
      {
        AddFirst(item);
        return "";
      }
      else
      {
        Node<T> indexNode = First, newNode = new Node<T>(item);
        for (int i = 0; i < index; i++)
          indexNode = indexNode.Next;
        if (indexNode.Previous == null)
        {
          indexNode.Previous = newNode;
          newNode.Next = indexNode;
          First = newNode;
        }
        else
        {
          indexNode.Previous.Next = newNode;
          newNode.Previous = indexNode.Previous;
          newNode.Next = indexNode;
          indexNode.Previous = newNode.Previous;
        }
        count++;
      return "";
      }
    } //должно работать

    public void Add(T item)
    {
      if (First == null)
      {
        First = new Node<T>(item);
        Last = First;
      }
      else
      {
        Last.Next = new Node<T>(item);
        Last.Next.Previous = Last;
        Last = Last.Next;
      }
      count++;
    }
#endregion

    //public string DeleteByIndex(int index)
    //{

    //}
    //public string DeleteByIndex(int index)
    //{
    //  if (index > count)
    //  Node current = First;
    //  for (int i = 1; i < index; i++)
    //    current = current.Next;


    //}

    #region Удаление
    internal void DeleteNode(Node<T> node)
    {
      if (node.Next == null && node.Previous == null) // нода - единственный элемент в списке
      {
        First = null;
        Last = null;
      }
      else if (node.Next == null)                     // нода - замыкающий элемент списка
      {
        Last = node.Previous;
        Last.Next = null;
      }
      else if (node.Previous == null)                 // нода - открывающий объект списка
      {
        First = node.Next;
        First.Previous = null;
      }
      else                                            // нода - срединный элемент списка
      {
        node.Next.Previous = node.Previous;
        node.Previous.Next = node.Next;
      }
      count--;
    }

    public string DeleteByName(string brandname)
    {
      if (count == 0)
        return "Удаление не удалось, так как в списке недостаточно элементов.";
      else
      {
        Node<T> current = First;
        int i;
        for (i = 1; i < count && current.Value.BrandName != brandname; i++)
        {
          current = current.Next;
        }
        if (current.Value.BrandName == brandname)
        {
          DeleteNode(current);
          return "Был удалён подходящий элемент.";
        }
        else
          return "Ничего удалено не было, так как не было найдено.";
      }
    }

    public string DeleteByYear(short yearOfIssue)
    {
      if (count == 0)
        return "Удаление не удалось, так как в списке недостаточно элементов.";
      else
      {
        Node<T> current = First;
        int i;
        for (i = 1; i < count && current.Value.YearOfIssue != yearOfIssue; i++)
        {
          current = current.Next;
        }
        if (current.Value.YearOfIssue == yearOfIssue)
        {
          DeleteNode(current);
          return "Был удалён подходящий элемент.";
        }
        else
          return "Ничего удалено не было, так как не было найдено.";
      }
    }

    public string DeleteFirst()
    {
      if (count == 0)
        return "Удаление не удалось, так как в списке недостаточно элементов.";
      if (First.Next != null)
      {
        First = First.Next;
        First.Previous = null;
      }
      else
        First = null;
      count--;

      return "";
    }

    public string DeleteLast()
    {
      if (count == 0)
        return "В списке недостаточно элементов для удаления.";
      if (count == 1)
      {
        First = null;
        Last = null;
      }
      else
      {
        Last = Last.Previous;
        Last.Next = null;
      }
      count--;
      return "";
    }
#endregion

  }
    public class Node<T>
    {
      public T Value { get; set; }
      public Node<T>? Next { get; set; }
      public Node<T>? Previous { get; set; }

      public Node()
      {
        Value = default;
        Previous = null;
        Next = null;
      }

      public Node(T value) //для первого элемента
      {
        Value = value;
        Previous = null;
        Next = null;
      }

      public Node(T value, Node<T> previous,  Node<T> next)
      {
        Value = value;
        Previous = previous;
        Next = next;
      }

      public override string? ToString()
      {
        return Value == null ? "" : Value.ToString();
      }

      public override int GetHashCode()
      {
        return Value == null ? 0 : Value.GetHashCode();
      }

      //public Node Clone() => new Node((T)Value.Clone());

    }
}