using System;

class Program
{
  static void DisplayWelcome()
  {
    Console.Write("Welcome to the program!");
  }
  static string PromptUserName()
  {
    Console.Write("Please enter your name: ");
    return Console.ReadLine();
  }
  static int PromptUserNumber()
  {
    while (true)
    {
      Console.Write("Please enter your favorite number: ");
      string raw = Console.ReadLine();
      if (int.TryParse(raw, out int num))
      {
        return num;
      }
      Console.Write("Not an Int. try again: ");
    }
  }
  static int SquareNumber(int num)
  {
    return num * num;
  }
  static void DisplayResult(string name, int square)
  {
    Console.Write($"{name}, the square of your number is {square}");
  }
  static void Main(string[] args)
  {
    DisplayWelcome();
    string name = PromptUserName();
    int num = PromptUserNumber();
    DisplayResult(name, SquareNumber(num));
  }
}