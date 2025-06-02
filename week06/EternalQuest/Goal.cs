// trying something new and defining an enum for the whole namespace.
public enum GoalType
{
  Simple,
  Eternal,
  Iterating
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

  public override void ShowActionMenu() { }

  public override void PrintGoalDetails() { }
}

