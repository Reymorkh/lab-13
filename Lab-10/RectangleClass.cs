using static Lab_10.Logic;

namespace Lab_10
{
  public class Rectangle : IInit, IComparable, ICloneable
  {
    private static int count = 0;

    private double length = 0.0001, width = 0.0001;

    #region EditParams
    public void EditLength(double len) => Length += len;

    public void EditWidth(double wid) => Width += wid;

    public void Multiply(double multiplier) => (Length, Width) = (Length * multiplier, Width * multiplier);

    public static void MultiplyStatic(double multiplier, Rectangle rect) => (rect.Length, rect.Width) = (rect.Length * multiplier, rect.Width * multiplier);
    #endregion

    #region GetParams
    public double Length
    {
      get
      {
        return length;
      }
      set
      {
        if (value > 46340.95)
          length = 46340.95;
        else
          if (value < 0.0001)
          length = 0.0001;
        else
          length = value;
      }
    }

    public double Width
    {
      get
      {
        return width;
      }
      set
      {
        if (value > 46340.9499)
          width = 46340.9499;
        else
          if (value < 0.0001)
          width = 0.0001;
        else
          width = value;
      }
    }

    public double Area { get => Width * Length; }

    public static int Count { get { return count; } }
    #endregion

    #region Конструкторы
    public Rectangle()
    {
      count++;
    }

    public Rectangle(double len, double wid)
    {
      Length = len;
      Width = wid;
      count++;
    }

    public Rectangle(Rectangle rect) => (length, width) = (rect.Length, rect.Width);
    #endregion

    public static Rectangle operator ++(Rectangle rect) => new Rectangle(rect.Length + 1, rect.Width + 1);
    public static Rectangle operator --(Rectangle rect) => new Rectangle(rect.Length - 1, rect.Width - 1);

    public static explicit operator double (Rectangle rect) => Math.Sqrt(Math.Pow(rect.Length, 2) + Math.Pow(rect.Width, 2)) / 2;
    public static implicit operator bool(Rectangle rect) => rect.Length == rect.Width;

    public static Rectangle operator +(Rectangle rect, double value) => new Rectangle(rect.Length + value, rect.Width + value);
    public static Rectangle operator +(double value, Rectangle rect) => new Rectangle(rect.Length + value, rect.Width + value);

    public static Rectangle operator -(Rectangle rect, double value) => new Rectangle(rect.Length - value, rect.Width - value);
    public static Rectangle operator -(double value, Rectangle rect) => new Rectangle(rect.Length - value, rect.Width - value);

    public  void Init()
    {
      this.Length = GetDouble("длину");
      this.Width = GetDouble("ширину");
    }

    public void RandomInit()
    {
      Random rng = new();
      this.Length = rng.NextDouble();
      this.Width = rng.NextDouble();
    }

    public override string ToString() => $"Прямоугольник с величнами сторон: {this.Length:F4} и {this.Width:f4}";

    public override bool Equals(object?  obj) 
    {
      if (obj == null || !(obj is Rectangle))
        return false;
      else
        return this.Length == ((Rectangle)obj).Length && this.Width == ((Rectangle)obj).Width;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(length, width, Length, Width);
    }

    public int CompareTo(object? obj)
    {
      if (obj != null && obj is Rectangle rect)
        return Area.CompareTo(rect.Area);
      return -1;
    }

    public object Clone()
    {
      throw new NotImplementedException();
    }
  }
}
