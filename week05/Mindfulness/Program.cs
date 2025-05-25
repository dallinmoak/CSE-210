using System;

class Program
{

  static bool GetMenuChoice()
  {
    bool invalidChoice = true;
    while (invalidChoice)
    {
      Console.Write("What kind of activity do you wanna do?\n");
      Console.Write("1. Breathing Activity\n");
      Console.Write("2. Reflection Activity\n");
      Console.Write("3. Listing Activity\n");
      Console.Write("4. Quit\n");
      Console.Write("Please make a choice: ");
      string choice = Console.ReadLine();
      if (int.TryParse(choice, out int choiceNum))
      {
        switch (choiceNum)
        {
          case 1:
            Console.Write("chose breathing");
            invalidChoice = false;
            break;
          case 2:
            Console.Write("chose reflection");
            invalidChoice = false;
            break;
          case 3:
            Console.Write("chose listing");
            invalidChoice = false;
            break;
          case 4:
            Console.Write("ok bye");
            return false;
          default:
            Console.Write("invalid input. ");
            break;
        }
      }
      else
      {
        Console.WriteLine("Invalid input. ");
      }
    }
    return true;
  }

  static void Main(string[] args)
  {
    bool again = true;
    while (again)
    {
      //if getMenuChoice returns false, the user chose to quit
      again = GetMenuChoice();
      // but if it returns true, the user just did an activity
      if (again)
      {
        Console.Write("Do you wanna do another? (Y/n) ");
        string againChoice = Console.ReadLine();
        if (againChoice.ToLower() == "n")
        {
          again = false;
          Console.Write("ok bye");
        }
        else
        {
          Console.Write("ok let's go again\n");
        }
      }
    }
  }
}