using System;

class Program
{

  static bool PrintMenuAndRun()
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
            BreathingActivity br = new BreathingActivity();
            br.Run();
            invalidChoice = false;
            break;
          case 2:
            ReflectionActivity re = new ReflectionActivity();
            re.Run();
            invalidChoice = false;
            break;
          case 3:
            ListingActivity li = new ListingActivity();
            li.Run();
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
      again = PrintMenuAndRun();
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