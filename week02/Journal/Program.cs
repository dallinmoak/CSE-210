using System;
using static Journal;

class Program
{
  static int getMenuChoice(bool loaded = false, string? savePath = null, bool firstTime = false)
  {
    if (!firstTime)
    {
      Console.Write("Press any key to return to the menu...");
      Console.ReadKey();
      Console.Clear();
    }
    Console.Write("Program Menu: ");
    if (loaded)
    {
      if (savePath != null)
      {

        Console.Write($"(journal is loaded from {savePath})\n");
      }
      else
      {
        Console.Write("(journal is loaded, but not saved to a file)\n");
      }
    }
    else
    {
      Console.Write("(no journal loaded)\n");
    }
    Console.Write("  1. write in current journal\n");
    Console.Write("  2. read current journal\n");
    Console.Write("  3. load a journal\n");
    Console.Write("  5. new journal\n");
    Console.Write("  6. quit\n");
    Console.Write("Enter your choice: ");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
      return choice;
    }
    else
    {
      Console.WriteLine("Invalid input. Please enter a number.");
      return getMenuChoice();
    }
  }
  static void Main(string[] args)
  {
    Journal? currentJournal = null;
    int choice = 0;
    Console.Clear();
    Console.Write("Welcome to the Journal program!\n");
    while (choice != 6)
    {
      choice = getMenuChoice(currentJournal != null, currentJournal?.GetLoadPath(), choice == 0);
      switch (choice)
      {
        case 1: // write in current journal
          if (currentJournal != null)
          {
            Console.Write("writing in current journal...\n");
            currentJournal.AddEntry();
            Console.Write("entry added.\n");
          }
          else
          {
            Console.Write("can't do that. no journal loaded.\n");
          }
          break;
        case 2: // read current journal
          if (currentJournal != null)
          {
            Console.Write("reading current journal...\n");
            currentJournal.PrintEntries();
          }
          else
          {
            Console.Write("no journal loaded.\n");
          }
          break;
        case 5: // new journal
          Console.Write("creating new journal...\n");
          currentJournal = new Journal();
          Console.Write("new journal created.\n");
          break;
        case 6: // quit
          Console.WriteLine("buhbye now\n");
          break;
        default:
          Console.WriteLine("Invalid choice. Please try again.\n");
          break;
      }
    }
  }
}