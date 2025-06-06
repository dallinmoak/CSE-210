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
  public abstract void PrintGoalDetails();

  public string GetLabel()
  {
    return this._label;
  }
}

class SimpleGoal : Goal
{
  public SimpleGoal() : base(GoalType.Simple) { }

  protected override void Init()
  {
    Console.Write("what do you wanna call it? ");
    string input = Console.ReadLine();
    base._label = input;
  }

  public override void ShowActionMenu()
  {
    while (true)
    {
      Console.Clear();
      Console.Write($"Goal menu for simple goal: {base._label}\n");
      Console.Write("choose a simple goal action:\n");
      Console.Write("1. test action\n");
      Console.Write("q. Quit to goal set menu\n");
      Console.Write("Please enter your choice: ");
      string choice = Console.ReadLine();
      if (choice == "q")
      {
        return;
      }
      else if (choice == "1")
      {
        Console.Write("here's a test action\n");
        Console.Write("did you finish doing the test action?");
        Console.ReadLine();
      }
    }
  }

  public override void PrintGoalDetails() { }
}

