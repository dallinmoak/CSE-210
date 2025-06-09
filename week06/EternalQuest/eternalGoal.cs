// I started out this class def by coping the simple goal class
class EternalGoal : Goal
{
  public EternalGoal() : base(GoalType.Eternal, fromSource: false) { }

  public EternalGoal(string label, int currentValue, int completionPoints) : base(GoalType.Eternal, fromSource: true)
  {
    this._label = label;
    this._currentValue = currentValue;
    this._completionPoints = completionPoints;
  }

  private int _completionPoints;

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
      Console.Write($"Goal menu for eternal goal: {base._label}\n");
      Console.Write($"Current points: {this._currentValue}/{this._completionPoints}\n");
      Console.Write("choose a eternal goal action:\n");
      Console.Write("1. work on Goal\n");
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
    this._currentValue += this._completionPoints;
    Console.WriteLine($"goal '{base._label}' worked on! Current points: {this._currentValue}/infinity");
    Console.WriteLine("\n press any key to continue");
    Console.ReadKey();
  }

  public override string GetLabel()
  {
    return $"{base._label} - {this._currentValue}/infinity points";
  }

  public override string GoalToString(string delimiter = "~")
  {
    return $"IteratingGoal{delimiter}" +
    $"{base._label}{delimiter}" +
    $"{this._currentValue}{delimiter}";
  }
}