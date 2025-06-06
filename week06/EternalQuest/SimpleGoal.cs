
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