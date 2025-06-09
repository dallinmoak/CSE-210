class IteratingGoal : Goal
{
  private int _completionPoints;
  private int _completedIterations;
  private int _iterations;
  private int _pointsPerIteration;

  public IteratingGoal() : base(GoalType.Iterating) { }

  public IteratingGoal(string label, int currentValue, int completionPoints, int completedIterations, int iterations, int pointsPerIteration)
    : base(GoalType.Iterating, fromSource: true)
  {
    this._label = label;
    this._currentValue = currentValue;
    this._completionPoints = completionPoints;
    this._completedIterations = completedIterations;
    this._iterations = iterations;
    this._pointsPerIteration = pointsPerIteration;
  }

  private bool IsComplete()
  {
    return this._completedIterations >= this._iterations;
  }

  private string PointBreakdown()
  {
    return $"{this._currentValue}/{this._completionPoints + (this._iterations * this._pointsPerIteration)}";
  }

  private string IterationBreakdown()
  {
    return $"{this._completedIterations}/{this._iterations}";
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
      Console.Write($"Current points: {this.PointBreakdown()}\n");
      Console.Write($"Completed iterations: {this.IterationBreakdown()}\n");
      Console.Write("choose an iterating goal action:\n");
      if (this.IsComplete())
      {
        Console.Write("x. Can't complete an already completed iterating goal\n");
      }
      else
      {
        Console.Write($"1. Complete Iteration for {this._pointsPerIteration} points\n");
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
      completionMessage = $"goal '{base._label}' completed {this.IterationBreakdown()} times ";
      completionMessage += $"for {this.PointBreakdown()} points";
    }
    else
    {
      completionMessage = $"goal '{base._label}' completed iteration {this.IterationBreakdown()}! ";
      completionMessage += $"Current points: {this.PointBreakdown()}";
    }
    Console.WriteLine(completionMessage + "\n press any key to continue");
    Console.ReadKey();
  }

  public override string GetLabel()
  {
    string completedClause = this.IsComplete() ?
     " (completed)" :
     $"({this.IterationBreakdown()} rounds done)";
    string pointsClause = this.PointBreakdown();
    return $"{base._label} - ({pointsClause} points); {completedClause}";
  }

  public override string GoalToString(string delimiter = "~")
  {
    return $"IteratingGoal{delimiter}" +
    $"{base._label}{delimiter}" +
    $"{this._currentValue}{delimiter}" +
    $"{this._completionPoints}{delimiter}" +
    $"{this._completedIterations}{delimiter}" +
    $"{this._iterations}{delimiter}" +
    $"{this._pointsPerIteration}";
  }
}