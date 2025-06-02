using System;
using System.Net.Quic;

class Program
{
  static void Main(string[] args)
  {
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
      string location = Console.ReadLine();
      goalSet = new GoalSet(location);
      bool close = false;
      while (!close)
      {
        close = goalSet.ShowMenu();
      }
      Console.Write("you've closed the goal set at " + location + "\n");
    }
  }
}