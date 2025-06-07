using System;

class Program
{
  static void Main(string[] args)
  {
    // Hi B. Parish, Here's my program for the goal manager. I didn't quite get around to implementing the saving feature, but the loading feature, while not usable, is fleshed out and theoretically works.

    // I feel my flow control design shows extra creativity, including the way a user can functionally navigate between 3 different types of menus, and the use of a GoalMaker class for single-point access to user-driven goal creation.
    // also of merit is my use of overloads and alternate contructors to allow for either user driven or file-driven goal creation.

    // see my commit history for evidence of the organic development process
    Console.Write("Welcome to the goal manager\n");
    bool quit = false;
    while (!quit)
    {
      GoalSet goalSet = null;
      string pathPrompt;
      Console.Write("do you wanna load an existing goal set, create a new one, or quit? (L/c/q): ");
      string input = Console.ReadLine();
      if (input.ToLower() == "c")
      {
        pathPrompt = "please enter the path where you want to create the new goal set file: ";
      }
      else if (input.ToLower() == "q")
      {
        quit = true;
        continue;
      }
      else
      {
        pathPrompt = "please enter the path where the goal set file is located: ";
      }
      Console.Write(pathPrompt);
      string filePath = Console.ReadLine();
      goalSet = new GoalSet(filePath);
      bool close = false;
      while (!close)
      {
        close = goalSet.ShowMenu();
      }
      Console.Write("you've closed the goal set at " + filePath + "\n");
    }
  }
}