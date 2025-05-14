class Fraction
{
  private int _top;
  private int _bottom;
  public Fraction()
  {
    this.Init(1, 1);
  }
  public Fraction(int top)
  {
    this.Init(top, 1);
  }

  public Fraction(int top, int bottom)
  {
    this.Init(top, bottom);
  }

  public void Print(bool ForceFraction = false)
  {
    if (ForceFraction || this._bottom != 1)
    {
      Console.WriteLine($"{this._top}/{this._bottom}");
    }
    else
    {
      Console.WriteLine(this._top);
    }
  }

  public void PrintDecimal()
  {
    Console.WriteLine($"{(double)this._top / (double)this._bottom}");
  }

  private void Init(int top, int bottom)
  {
    this.SetTop(top);
    this.SetBottom(bottom);
  }

  public int GetTop()
  {
    return this._top;
  }
  public int GetBottom()
  {
    return this._bottom;
  }
  public void SetTop(int top)
  {
    this._top = top;
  }
  public void SetBottom(int bottom)
  {
    if (bottom == 0)
    {
      throw new Exception("Denominator cannot be zero");
    }
    this._bottom = bottom;
  }
}