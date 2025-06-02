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

  public void AddGoal() { }

  public void PrintGoalList(bool detailed = false) { }

  public void PrintStats() { }

  public void SelectAGoal()
  {
    // TODO: print all goals using this.PrintGoalList() and then ask for a number that's an index of the list to interact with
  }

  public bool ShowMenu()
  {
    Console.Clear();
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
    bool close = activeGoal.ShowActionMenu();
    // user will do something with the active goal or choose to close this goal set
    return close;
  }

}