﻿using Lab_10;
using static Lab_10.Logic;
using lab_12;
using System.Collections;

namespace lab_13
{
  public delegate void CollectionHandler(object source, CollectionHandlerEventArgs e);

  public class MyObservableCollection<T> : MyCollection<T>, IList<T> where T : IBaseProperties, ICloneable, IInit, new()
  {
    public event CollectionHandler CollectionCountChanged, CollectionReferenceChanged;

    public void OnChange(object source, CollectionHandlerEventArgs e)
    {
      CollectionCountChanged?.Invoke(source, e);
    }
    public void OnReferenceChange(object source, CollectionHandlerEventArgs e)
    {
      CollectionReferenceChanged?.Invoke(source, e);
    }

    bool isReadOnly = false;
    
    public MyObservableCollection() { }

    public MyObservableCollection(int length, Journal journal) : base(length)
    {
      this.CollectionCountChanged += journal.WriteRecord;
      OnChange(null, new CollectionHandlerEventArgs(null, "Была создана коллекция на  " + length + " элементов"));
    }

    delegate int Handler(T item, T example);

    #region
    int IdentityCheck(T item, T example)
    {
      if (item.GetType() == example.GetType() && item.YearOfIssue == example.YearOfIssue && item.BrandName == example.BrandName)
        return 1;
      else
        return -1;
    } //сделано


    #endregion

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

    Node<T> GetNodeWithIndex(int index)
    {
      if (index > Count - 1)
        throw new ArgumentOutOfRangeException();
      Node<T> result = First;
      for (int i = 0; i < index; i++)
        result = result.Next;
      return result;
    }

    public T this[int index]
    {
      get => GetNodeWithIndex(index).Value;
      set => GetNodeWithIndex(index).Value = value;
    } //сделано

    public bool IsReadOnly { get => isReadOnly; }

    public void Clear()
    {
      this.CollectionReset();
    } //сделано

    public bool Contains(T item)
    {
      if (ForEach(item, IdentityCheck) == 1)
        return true;
      else
        return false;
    } //сделано

    public void CopyTo(T[] array, int arrayIndex)
    {
      Node<T> node = GetNodeWithIndex(arrayIndex);
      for (int i = 0; i < array.Length && node != null; i++)
      {
        array[i] = node.Value;
        node = node.Next;
      }

    } // сделано

    public int IndexOf(T item) 
    {
      Node<T> temp = First;
      int counter = 0;
      while (temp != null)
      {
        if (item.GetType() == temp.Value.GetType() && item.YearOfIssue == temp.Value.YearOfIssue && item.BrandName == temp.Value.BrandName)
          return counter;
        temp = temp.Next;
        counter++;
      }
      return -1;
    } // сделано

    public void Insert(int index, T item, string collname)
    {
      Insert(item, index);
      OnChange(this[index], new CollectionHandlerEventArgs(index, "Был добавлен", this[index], collname));
    } //сделано

    public bool Remove(T item, string collname)
    {
      int index = IndexOf(item);
      if (index > -1)
      {
        OnChange(this[index], new CollectionHandlerEventArgs(index, "Был удалён", this[index], collname));
        DeleteNode(GetNodeWithIndex(index));
      }
      else
        return false;
      return true;
    } //сделано

    public void RemoveAt(int index, string collname = null)
    {
      if (index > -1)
      {
        OnChange(this[index], new CollectionHandlerEventArgs(index, "Был удалён", this[index], collname));
        DeleteNode(GetNodeWithIndex(index));
      }
    } //сделано

    public void Replace(int index,T item, string collname = null)
    {
      OnReferenceChange(this[index], new CollectionHandlerEventArgs(index, $"Объект {this[index]}с номером {index + 1} был заменён новым элементом {item}", this[index] + (collname == null ? "." : $". коллекция: {collname}")));
      GetNodeWithIndex(index).Value = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
      T[] values = new T[Count];
      CopyTo(values, 0);
      return values.Take(Count).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    public void Insert(int index, T item)
    {
      Insert(index, item, null);
    }

    public void RemoveAt(int index)
    {
      RemoveAt(index, null);
    }

    public bool Remove(T item)
    {
      return Remove(item, null);
    }

    //}

    //class Enumer<T>// where T : IBaseProperties, ICloneable, IInit, new()
    //{
    //Node<T> example;
    //Enumer(Node<T> node)
    //{
    //  example = node;
    //}

    //void IEnumerator.Reset() => position = -1;

    //int position = -1;

    //object Current
    //{
    //  get
    //  {
    //    if (position == -1 || position > Count - 1)
    //      throw new ArgumentException();
    //    return this[position]; ;
    //  }
    //}

    //object IEnumerator.Current => throw new NotImplementedException();

    //bool IEnumerator.MoveNext()
    //{
    //  if (position < Count - 1)
    //  {
    //    position++;
    //    return true;
    //  }
    //  else
    //    return false;
    //}
    //}
  }
}