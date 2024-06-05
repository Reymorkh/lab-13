using Lab_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_12
{
  //class BinaryTree<T> where T : IBaseProperties, new()
  //{
  //  public T Value { get; set; }          //Информационное поле
  //  public BinaryTree<T> left, right;              //Адресное поле левого и правого поддерева 
  //  int Count = 0;

  //  public BinaryTree()
  //  {
  //    Value = new T();
  //    left = null;
  //    right = null;
  //  }

  //  public BinaryTree(int i, string s)
  //  {
  //    Value = new T(i, s);
  //    left = null;
  //    right = null;
  //  }

  //  public int Run(BinaryTree<T> p)
  //  {
  //    if (p != null)
  //    {
  //      this.Count++;
  //      Run(p.left);
  //    }
  //    return this.Count;
  //  }

  //  public static BinaryTree<T> First()
  //  {
  //    BinaryTree<T> p = new BinaryTree<T>(5, "root");
  //    return p;
  //  }

  //  public static BinaryTree<T> Add(BinaryTree<T> root, int gr, string s)
  //  {
  //    BinaryTree<T> p = root;
  //    BinaryTree<T> r = null;
  //    bool ok = false;
  //    while (p != null && !ok)
  //    {
  //      r = p;
  //      if ((gr == p.Value.YearOfIssue) && (s == p.Value.BrandName)) ok = true;
  //      else
  //          if (gr < p.Value.YearOfIssue) p = p.left;
  //      else p = p.right;
  //    }
  //    if (ok) return p;
  //    BinaryTree<T> NewPoint = new BinaryTree<T>(gr, s);
  //    if (gr < r.Value.YearOfIssue) r.left = NewPoint;
  //    else r.right = NewPoint;
  //    return NewPoint;
  //  }

  //  public static BinaryTree<T> IdealTree(int size, BinaryTree<T> p)
  //  {
  //    Random rnd = new Random();
  //    string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
  //    BinaryTree<T> r;
  //    int nl, nr;
  //    if (size == 0) { p = null; return p; }
  //    nl = size / 2;
  //    nr = size - nl - 1;
  //    r = new BinaryTree<T>(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
  //    r.left = IdealTree(nl, r.left);
  //    r.right = IdealTree(nr, r.right);
  //    return r;
  //  }

  //  public static void Transform(BinaryTree<T> root, BinaryTree<T> idtree)
  //  {
  //    if (idtree != null)
  //    {
  //      Add(root, idtree.Value.YearOfIssue, idtree.Value.YearOfIssue);
  //      Transform(root, idtree.left);
  //      Transform(root, idtree.right);
  //    }
  //  }

  //}
}
