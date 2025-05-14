class Fraction
{
  private int top;
  private int bottom;
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
    if (ForceFraction || this.bottom != 1)
    {
      Console.WriteLine($"{this.top}/{this.bottom}");
    }
    else
    {
      Console.WriteLine(this.top);
    }
  }

  public void PrintDecimal()
  {
    Console.WriteLine($"{(double)this.top / (double)this.bottom}");
  }

  private void Init(int top, int bottom)
  {
    this.SetTop(top);
    this.SetBottom(bottom);
  }

  public int GetTop()
  {
    return this.top;
  }
  public int GetBottom()
  {
    return this.bottom;
  }
  public void SetTop(int top)
  {
    this.top = top;
  }
  public void SetBottom(int bottom)
  {
    if (bottom == 0)
    {
      throw new Exception("Denominator cannot be zero");
    }
    this.bottom = bottom;
  }
}