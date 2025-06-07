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

  public Goal(GoalType type, bool fromSource = false)
  {
    this._type = type;
    this._currentValue = 0;
    if (!fromSource)
    {
      this.Init();
    }
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