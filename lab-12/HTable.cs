
using Lab_10;

namespace lab_12
{
  internal class HTable<T> where T: IInit, ICloneable, new()
  {
    public Node<T>[]? table;
    public int Size { get; set; }
    const double loadFactor = 0.72;
    int hashSize = 0;

    public HTable(int size)
    {
      Size = size;
      table = new Node<T>[Size];
    }

    public bool Add(T item)
    {
      if (item == null)
        return false;
      if (hashSize / table.Length < loadFactor)
        TableResize(table.Length * 2);
      Node<T> newNode = new Node<T>(item);
      int index = GetIndex(newNode);
      if (table[index] == null)
        table[index] = newNode;
      else
      {
        Node<T> cur = table[index];
        if (string.Compare(cur.ToString(), newNode.ToString()) == 0)
          return false;
        while (cur.Next != null)
        {
          if (string.Compare(cur.ToString(), newNode.ToString()) == 0)
            return false;
          cur = cur.Next;
        }
        cur.Next = newNode;
      }
      hashSize++;
      return true;
    }




    void TableResize(int length)
    {

    }
    // public Node<T> this[int index] { get => table[index] == null ? throw new NullReferenceException("") : table[index]; }

    public int GetIndex(Node<T> node) => Math.Abs(node.GetHashCode()) % Size;

  }

  class Node<T>
  {
    public int key;
    public T? Value { get; set; }

    public Node<T>? Next { get; set; }
    public Node(T item)
    {
      Value = item;
      key = GetHashCode();
      Next = null;
    }

    public override string ToString()
    {
      return Value == null ? "0" : key + ":" + Value.ToString();
    }
    public override int GetHashCode()
    {
      return Value == null ? 0 : Value.GetHashCode();
    }




  }
}