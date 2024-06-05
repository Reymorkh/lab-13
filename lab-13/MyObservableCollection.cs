using Lab_10;
using static Lab_10.Logic;
using lab_12;
using System.Collections;

namespace lab_13
{
  internal class MyObservableCollection<T> : MyCollection<T>, IList<T> where T : IBaseProperties, ICloneable, IInit, new()
  {
    public MyObservableCollection() { }

    delegate int Handler(T item, T example);

    int ForEach(T item, Handler handler)
    {
      Node<T> tempNode = First;
      if (tempNode == null)
        return -1;
      else
      {
        while (tempNode != null)
        {
          int temp = handler(tempNode.Value, item);
          if (temp > -1)
            return temp;
          tempNode = tempNode.Next;
        }
        return -1;
      }
    }

    int IdentityCheck(T item, T example)
    {
      if (item.GetType() == example.GetType() && item.YearOfIssue == example.YearOfIssue && item.BrandName == example.BrandName)
        return 1;
      else
        return -1;
    }


    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool IsReadOnly => throw new NotImplementedException();

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
      if (ForEach(item, IdentityCheck) == 1)
        return true;
      else
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
      throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
      Insert(item, index);
    }

    public bool Remove(T item)
    {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }
  }
}