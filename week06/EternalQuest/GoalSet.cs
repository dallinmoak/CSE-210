class GoalSet
{
  public string location;
  public List<Goal> goals;
  public int totalScore;
  private int _activeGoalIndex = -1;

  public GoalSet(string location)
  {
    // TODO: attempt to load at location, if no file, create new
    bool foundIt = false;
    if (foundIt)
    {
      this.Load(location);
    }
    else
    {
      this.location = location;
      this.goals = new List<Goal>();
      this.totalScore = 0;
    }
  }

  public void Save() { }

  public void Load(string location)
  {
    // read the contents of a file at location and populate the goals list with the goals found in the file, setting the totalScore accordingly
  }

  public void AddGoal()
  {
    Console.Write("Adding a new goal...\n");
    Goal g = new SimpleGoal();
    this.goals.Add(g);
  }

  public void PrintGoalList(bool detailed = false) { }

  public void PrintStats() { }

  public void SelectAGoal()
  {
    // TODO: print all goals using this.PrintGoalList() and then ask for a number that's an index of the list to interact with
    bool validInput = false;
    while (!validInput)
    {
      this.PrintGoalList();
      Console.Write("Select a goal by its index: ");
      string input = Console.ReadLine();
      if (int.TryParse(input, out int indexChoice) && indexChoice >= 0 && indexChoice < this.goals.Count)
      {
        this._activeGoalIndex = indexChoice;
        validInput = true;
      }
      else
      {
        Console.Write("Invalid index. Please try again.\n");
      }
    }
  }

  public bool ShowMenu()
  {
    Console.Clear();
    Console.Write("this is the goalset menu for goalset " + this.location + "\n");
    while (this.goals.Count == 0)
    {
      Console.Write("no goals in this goal set. add one? Y/n: ");
      string input = Console.ReadLine();
      if (input.ToLower() != "n")
      {
        this.AddGoal();
        // at this point this.goals.Count will be 1 or more, the loop will end
      }
      else
      {
        Console.Write("nothing to do here, either close or add a goal (A/c): ");
        input = Console.ReadLine();
        if (input.ToLower() == "c")
        {
          return true;
        }
        // else, continue and re-prompt to add a goal
      }
    }
    Console.Write($"currently accessing the goal set at: {this.location}\n");
    this.PrintGoalList();
    this.PrintStats();
    if (this._activeGoalIndex == -1)
    {
      // no active goal, prompt to select one
      Console.WriteLine("No active goal. Please select a goal to work on.");
      this.SelectAGoal();
    }
    // show the menu for the active goal
    Goal activeGoal = this.goals[this._activeGoalIndex];
    activeGoal.ShowActionMenu();
    // user wis done interacting with the active goal
    this._activeGoalIndex = -1;
    Console.Write("Do you want to continue working on this goal set? (Y/n): ");
    string continueInput = Console.ReadLine();
    return continueInput.ToLower() == "n";
  }

}