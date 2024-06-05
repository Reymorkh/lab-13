using static Lab_10.Logic;

namespace Lab_10
{
  public class DigitalWatch : Watch, IInit, IComparable, ICloneable
  {
    private string displayType = "No display";

    public string DisplayType
    {
      get => displayType;
      internal set { if (value != null) displayType = value; else throw new NullReferenceException(); }
    }

    public DigitalWatch() { }
    public DigitalWatch(string name, short year, string display) : base(name, year) => DisplayType = display;

        public Watch GetBase => new Watch(BrandName, YearOfIssue);
    public override string ToString() => "DigitalWatch: " + BrandName + "; " + YearOfIssue + "; " + DisplayType;
    public override void Init() => (this.BrandName, this.YearOfIssue, this.DisplayType) = (GetString("имя бренда"), GetShort("год выпуска"), GetString("дисплей"));
    public override void RandomInit()
    {
      Random rng = new();
      this.BrandName = Brands[rng.Next(Brands.Length)];
      this.YearOfIssue = (short)rng.Next(1, 2024);//(1970, 2024);
      this.DisplayType = DisplayTypes[rng.Next(DisplayTypes.Length)];
    }


    public override bool Equals(object? obj)
    {
      //if (obj == null || obj is not DigitalWatch watch)
      //  return false;
      return base.Equals(obj) && ((DigitalWatch)obj).DisplayType == this.DisplayType;
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

  //  public override object ShallowCopy() => MemberwiseClone();

    public override object Clone()
    {
            DigitalWatch watch = new DigitalWatch();
      watch.BrandName = BrandName;
      watch.YearOfIssue = YearOfIssue;
      watch.DisplayType = DisplayType;
      return watch;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(BrandName, YearOfIssue, displayType, DisplayType);
    }
  }
}