using System;

class Program
{
  static void Main(string[] args)
  {
    bool again = true;
    while (again)
    {
      Console.Write("Enter a numeric grade between 0 & 100 inclusive: ");
      string input = Console.ReadLine();

      if (!int.TryParse(input, out int grade) || grade < 0 || grade > 100)
      {
        // input validation
        Console.WriteLine("Invalid input. Please enter a numeric grade between 0 and 100.");
        continue;
      }
      string letterGrade;
      if (grade < 60)
      {
        letterGrade = "F";
      }
      else if (grade < 70)
      {
        letterGrade = "D";
      }
      else if (grade < 80)
      {
        letterGrade = "C";
      }
      else if (grade < 90)
      {
        letterGrade = "B";
      }
      else
      {
        letterGrade = "A";
      }
      string gradeWithModifier;
      // cover cases where the grade ends with 7, 8, or 9 AND is above and F
      // cover cases special case of Fs not getting modifiers and A+ not being a thing.
      if (letterGrade == "F" || grade >= 97)
      {
        gradeWithModifier = letterGrade;
      }
      else if (grade % 10 >= 7)
      {
        gradeWithModifier = letterGrade + "+";
      }
      // cover cases where the grade ends with 0, 1, or 2 AND is above and F
      else if (grade % 10 < 3)
      {
        gradeWithModifier = letterGrade + "-";
      }
      // default to no modifier
      else
      {
        gradeWithModifier = letterGrade;
      }

      Console.Write($"Your grade is a(n) {gradeWithModifier}.");
      Console.Write($"\n{grade}, or {gradeWithModifier} is a {(grade >= 70 ? "passing" : "failing")} grade.\n");

      // basic control flow
      Console.Write("\nTry again? (Y/n): ");
      string tryAgain = Console.ReadLine().ToLower();
      if (tryAgain == "n")
      {
        again = false;
      }
      else
      {
        Console.WriteLine("\n\n");
      }
    }
  }
}