using System;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    bool again = true;
    while (again)
    {

      Console.Write("Enter a list of numbers, type 0 when finished.\n");
      List<int> numbers = [];
      bool stillAdding = true;
      while (stillAdding)
      {
        Console.Write("Enter a number: ");
        string rawNum = Console.ReadLine();
        if (int.TryParse(rawNum, out int num) && num >= 0)
        {
          if (num == 0)
          {
            stillAdding = false;
          }
          else
          {
            numbers.Add(num);
          }
        }
      }
      Console.Write("The list is: [");
      for (int i = 0; i < numbers.Count; i++)
      {
        Console.Write(numbers[i]);
        if (i != numbers.Count - 1)
        {
          Console.Write(", ");
        }
      }
      Console.Write("]\n");
      int sum = 0;
      foreach (int num in numbers)
      {
        sum += num;
      }
      Console.Write($"The sum is: {sum}\n");
      float fSum = sum;
      float fCount = numbers.Count;
      float average = fSum / fCount;
      Console.Write($"The average is: {average}\n");
      int max = 0;
      foreach (int num in numbers)
      {
        if (num > max)
        {
          max = num;
        }
      }
      Console.Write($"The maximum is: {max}\n");

      // outer loop control:
      Console.Write("Do you want to play again? (Y/n): ");
      string againRes = Console.ReadLine().ToLower();
      if (againRes == "n")
      {
        again = false;
      }
      else
      {
        Console.Write("\n\n");
      }
    }
  }
}