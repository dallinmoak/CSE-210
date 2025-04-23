using System;

class Program
{
  static void Main(string[] args)
  {
    // outer loop, for playing another round of guessing
    bool again = true;
    Console.Write("Welcome to the guessing game.\n");
    while (again)
    {
      //play game
      //  inner loop for guessing
      bool stillGuessing = true;
      int guessCount = 0;
      int target = new Random().Next(1, 101);
      while (stillGuessing)
      {
        Console.Write("Guess a number between 1 and 100: ");
        // second inner loop for collecting valid inputs
        bool validInput = false;
        while (!validInput)
        {
          string guessRaw = Console.ReadLine();
          if (!int.TryParse(guessRaw, out int currentGuess) || currentGuess < 1 || currentGuess > 100)
          {
            Console.WriteLine("Bad input. Enter an integer between 1 and 100.");
            continue;
          }
          else
          {
            validInput = true;
            guessCount++;
            // check if the guess is correct
            if (currentGuess == target)
            {
              Console.WriteLine($"Correct. The number was {target}. It took you {guessCount} tries.");
              stillGuessing = false;
            }
            else if (currentGuess < target)
            {
              Console.WriteLine($"guess of {currentGuess} is too low. Try again.");
            }
            else
            {
              Console.WriteLine($"guess of {currentGuess} is too high. Try again.");
            }
          }
        }
      }
      // end play game

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