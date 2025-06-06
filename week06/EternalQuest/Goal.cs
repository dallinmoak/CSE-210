// trying something new and defining an enum for the whole namespace.
public enum GoalType
{
  Simple,
  Eternal,
  Iterating
}

class GoalMaker
{
  private char _type;
  public GoalMaker()
  {
    Console.Write("make a (s)imple goal, (e)ternal goal, or (i)terating goal? (s/e/i): ");
    _type = Console.ReadLine()[0];

  }

  public Goal Make()
  {
    switch (_type)
    {
      case 's':
        return new SimpleGoal();
      case 'i':
        return new IteratingGoal();
      default:
        return null;
    }
  }
}

abstract class Goal
{
  public GoalType _type;
  protected string _label;
  protected int _currentValue;

  public Goal(GoalType type)
  {
    this._type = type;
    this._currentValue = 0;
    this.Init();
  }

  protected int getInt(string prompt)
  {
    Console.Write(prompt);
    while (true)
    {
      string input = Console.ReadLine();
      if (int.TryParse(input, out int value))
      {
        return value;
      }
      else
      {
        Console.Write("Invalid input. Please enter a valid number: ");
      }
    }
  }

  protected abstract void Init();
  public abstract void ShowActionMenu();
  public abstract string GetLabel();
}

class SimpleGoal : Goal
{
  public SimpleGoal() : base(GoalType.Simple) { }
  private int _completionPoints;

  private bool IsComplete()
  {
    return this._currentValue >= this._completionPoints;
  }

  protected override void Init()
  {
    Console.Write("what do you wanna call it? ");
    string input = Console.ReadLine();
    base._label = input;
    this._completionPoints = base.getInt("how many points do you want it to be worth? ");
  }

  public override void ShowActionMenu()
  {
    Console.Clear();
    while (true)
    {
      Console.Write($"Goal menu for simple goal: {base._label}\n");
      Console.Write($"Current points: {this._currentValue}/{this._completionPoints}\n");
      Console.Write("choose a simple goal action:\n");
      if (this.IsComplete())
      {
        Console.Write("x. Can't complete an already completed simple goal\n");
      }
      else
      {
        Console.Write("1. Complete Goal\n");
      }
      Console.Write("q. Quit to goal set menu\n");
      Console.Write("Please enter your choice: ");
      string choice = Console.ReadLine();
      switch (choice.ToLower())
      {
        case "1":
          this.Complete();
          break;
        case "q":
          return;
        default:
          Console.WriteLine("Invalid input. Please try again.");
          break;
      }
      Console.Clear();
    }
  }

  private void Complete()
  {
    if (this.IsComplete())
    {
      Console.WriteLine($"goal '{base._label}' is already completed");
      return;
    }
    this._currentValue = this._completionPoints;
    Console.WriteLine($"goal '{base._label}' completed! Current points: {this._currentValue}/{this._completionPoints}");
    Console.WriteLine("\n press any key to continue");
    Console.ReadKey();
  }

  public override string GetLabel()
  {
    return $"{base._label}{(this.IsComplete() ? " (completed)" : "")} - {this._currentValue}/{this._completionPoints} points";
  }
}

class IteratingGoal : Goal
{
  private int _completionPoints;
  private int _completedIterations;
  private int _iterations;
  private int _pointsPerIteration;

  public IteratingGoal() : base(GoalType.Iterating) { }

  private bool IsComplete()
  {
    return this._completedIterations >= this._iterations;
  }

  protected override void Init()
  {
    Console.Write("what to call the iterating goal? ");
    string input = Console.ReadLine();
    base._label = input;
    this._completionPoints = base.getInt("how many points to complete the goal? ");
    this._iterations = base.getInt("how many iterations to complete the goal? ");
    this._pointsPerIteration = base.getInt("how many points to add each time you complete it? ");
  }

  public override void ShowActionMenu()
  {
    Console.Clear();
    while (true)
    {
      Console.Write($"goal menu for iterating goal {base._label}\n");
      Console.Write($"Current points: {this._currentValue}/{this._completionPoints + (this._iterations * this._pointsPerIteration)}\n");
      Console.Write($"Completed iterations: {this._completedIterations}/{this._iterations}\n");
      Console.Write("choose an iterating goal action:\n");
      Console.Write("1. complete an iteration\n");
      Console.Write("q. quit to the goalset menu\n");
      Console.Write("Please enter your choice: ");
      string choice = Console.ReadLine();
      switch (choice.ToLower())
      {
        case "1":
          this.CompleteIteration();
          break;
        case "q":
          return;
        default:
          Console.WriteLine("Invalid input. Please try again.");
          break;
      }
      Console.Clear();
    }
  }

  private void CompleteIteration()
  {
    if (this.IsComplete())
    {
      Console.WriteLine($"goal '{base._label}' is already completed");
      return;
    }
    this._completedIterations++;
    string completionMessage = "";
    this._currentValue += this._pointsPerIteration;
    if (this._completedIterations == this._iterations)
    {
      completionMessage = $"goal '{base._label}' completed {this._completedIterations}/{this._iterations} times for {this._currentValue}/{this._completionPoints + (this._iterations * this._pointsPerIteration)} points";
    }
    else
    {
      completionMessage = $"goal '{base._label}' completed iteration {this._completedIterations}/{this._iterations}! Current points: {this._currentValue}/{this._completionPoints + (this._iterations * this._pointsPerIteration)}";
    }
    Console.WriteLine(completionMessage + "\n press any key to continue");
    Console.ReadKey();
  }

  public override string GetLabel()
  {
    string completedClause = this._completedIterations >= this._iterations ? " (completed)" : $"({this._completedIterations}/{this._iterations} rounds done)";
    return $"{base._label} - ({this._currentValue}/{this._completionPoints + (this._iterations * this._pointsPerIteration)} points); {completedClause}";
  }
}