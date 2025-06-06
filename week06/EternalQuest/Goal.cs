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
    Console.Write("how many points do you want it to be worth? ");
    bool validInput = false;
    while (!validInput)
    {
      string valueInput = Console.ReadLine();
      if (int.TryParse(valueInput, out int points))
      {
        _completionPoints = points;
        validInput = true;
      }
      Console.Write("Invalid input. Please enter a valid number for points: ");
    }
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
  }

  public override string GetLabel()
  {
    return $"{base._label}{(this.IsComplete() ? " (completed)" : "")} - {this._currentValue}/{this._completionPoints} points";
  }
}

class IteratingGoal : Goal
{
  public IteratingGoal() : base(GoalType.Iterating) { }

  protected override void Init() { }

  public override void ShowActionMenu() { }

  public override string GetLabel() { return ""; }
}