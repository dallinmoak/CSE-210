using System;

class Program
{
  static void Main(string[] args)
  {
    bool done = false;
    while (!done)
    {
      Console.Write("ok let's do a scripture\n");
      Memorizer m = new Memorizer();
      m.PromptForContentAndRef(); // prompt for content and reference
      m.Display(); // clear the screen & display
      bool keepGoing = m.PromptToMemorize(); // prompt to memorize: option to quit and go back to main menu
      if (keepGoing)
      {
        bool gaveUp = m.Memorize(); // memorize the scripture, iterate till done
        if (gaveUp)
        {
          continue;
        }
        else
        {
          m.Congratulate(); // congratulate the user
        }
      }
      Console.Write("Do you want to go again with a new scripture? (Y/n): ");
      string input = Console.ReadLine();
      if (input.ToLower() == "n")
      {
        Console.WriteLine("Goodbye!");
        done = true;
      }
      else
      {
        continue;
      }
    }
  }
}