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
      if (this.IsComplete())
      {
        Console.Write("x. Can't complete an already completed iterating goal\n");
      }
      else
      {
        Console.Write("1. Complete Iteration\n");
      }
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
    string completionMessage;
    this._currentValue += this._pointsPerIteration;
    if (this._completedIterations == this._iterations)
    {
      this._currentValue += this._completionPoints;
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