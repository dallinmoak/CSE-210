using System;

class Program
{
  static void Main(string[] args)
  {
    // fraction constructed with no parameters
    Fraction frac1 = new Fraction();
    Console.WriteLine($"frac1's top is {frac1.GetTop()} and bottom is {frac1.GetBottom()}");
    frac1.Print();
    // print with a forced fraction
    frac1.Print(ForceFraction: true);
    // fraction constructed with one parameter
    Fraction frac2 = new Fraction(5);
    Console.WriteLine($"frac2's top is {frac2.GetTop()} and bottom is {frac2.GetBottom()}");
    frac2.Print();
    // fraction constructed with two parameters
    Fraction frac3 = new Fraction(3, 4);
    Console.WriteLine($"frac3's top is {frac3.GetTop()} and bottom is {frac3.GetBottom()}");
    frac3.Print();
    frac3.PrintDecimal();
    // changing a fractions values
    frac3.SetTop(1);
    frac3.SetBottom(3);
    Console.WriteLine($"frac3's top is now {frac3.GetTop()} and bottom is now {frac3.GetBottom()}");
    frac3.Print();
    frac3.PrintDecimal();
  }
}
