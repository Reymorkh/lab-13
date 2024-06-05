using static Lab_10.Logic;
namespace Lab_10
{
  public class AnalogWatch : Watch, IInit, IComparable, ICloneable
  {
    private string style = "No style";

    public string Style
    {
      get => style;
      private set => style = value;
    }

    public AnalogWatch() { }
    public AnalogWatch(string name, short year, string sty) : base(name, year) => Style = sty; 

    public override string ToString() => "AnalogWatch: " + BrandName + "; " + YearOfIssue + "; " + Style;
    public override void Init() => (this.BrandName, this.YearOfIssue, this.Style) = (GetString("имя бренда"), GetShort("год выпуска"), GetString("стиль"));
    public override void RandomInit()
    {
      Random rng = new();
      this.BrandName = Brands[rng.Next(Brands.Length)];
      this.YearOfIssue = (short)rng.Next(1368, 2024);
      this.Style = Styles[rng.Next(Styles.Length)];
    }

    public override bool Equals(object? obj)
    {
      //if (obj == null || obj is not AnalogWatch watch)
      //  return false;
      return base.Equals(obj) && ((AnalogWatch)obj).Style == this.Style;
    }

    //public override int CompareTo(object? obj)
    //{
    //  if (obj != null)
    //  {
    //    if (obj is Watch watch)
    //      return YearOfIssue.CompareTo(watch.YearOfIssue);
    //    if (obj is Rectangle)
    //      return 1;
    //    return -1;
    //  }
    //  throw new ArgumentNullException();
    //}

    public override object Clone()
    {
      AnalogWatch watch = new AnalogWatch();
      watch.BrandName = BrandName;
      watch.YearOfIssue = YearOfIssue;
      watch.Style = Style;
      return watch;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(base.GetHashCode(), BrandName, YearOfIssue, Style);
    }

    //public override object ShallowCopy() => MemberwiseClone();
  }
}