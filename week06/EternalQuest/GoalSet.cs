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

  public void AddGoal(string header)
  {
    Console.Clear();
    if (header != "")
    {
      Console.Write($"{header}\n");
    }
    Goal g = new GoalMaker().Make();
    // Goal g = new SimpleGoal();
    this.goals.Add(g);
  }

  public void PrintGoalList(bool detailed = false)
  {
    Console.Write("goal list:\n");
    for (int i = 0; i < this.goals.Count; i++)
    {
      Console.Write($" {i}: {this.goals[i].GetLabel()}\n");
    }
  }

  public void PrintStats()
  {
    Console.Write("stats:\n");
  }

  public void SelectAGoal(string header = "")
  {
    bool validInput = false;
    while (!validInput)
    {
      Console.Clear();
      if (header != "")
      {
        Console.Write($"{header}\n");
      }
      Console.Write("Select a goal by its index: ");
      this.PrintGoalList();
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

  public bool ShowMenu(bool r = false)
  {
    Console.Clear();
    if (r)
    {
      Console.Write("running goalset menu recursively\n");
    }
    Console.Write($"this is the goalset menu for goalset {this.location}\n");
    if (this.goals.Count == 0)
    {
      this.AddGoal(header: $"no goals on goalset {this.location}. let's add a the first one");
      bool result = this.ShowMenu(r: true);
      return result;
    }
    this.PrintGoalList();
    this.PrintStats();
    Console.Write("want to (a)dd a goal, (w)ork on a goal, or (c)lose this goalset? (a/W/c): ");
    string input = Console.ReadLine();
    if (input.ToLower() == "a")
    {
      this.AddGoal(header: $"adding a goal for goalset {this.location}");
      bool result = this.ShowMenu(r: true);
      return result;
    }
    else if (input.ToLower() == "c")
    {
      return true;
    }
    if (this._activeGoalIndex == -1)
    {
      this.SelectAGoal(header: "there isn't an active goal in this set right now. let choose one.");
      bool result = this.ShowMenu(r: true);
      return result;
    }
    Console.Write($"active goal is {this._activeGoalIndex}: {this.goals[_activeGoalIndex].GetLabel()}\n");
    Console.Write("want to (i)nteract with the active goal or (s)elect a different? (I/s): ");
    string workOnGoalinput = Console.ReadLine();
    if (workOnGoalinput.ToLower() == "s")
    {
      this.SelectAGoal(header: $"selecting a goal for goalset {this.location}");
      bool result = this.ShowMenu(r: true);
      return result;
    }
    Goal activeGoal = this.goals[this._activeGoalIndex];
    activeGoal.ShowActionMenu();
    Console.Write("Do you want to continue working on this goal set? (Y/n): ");
    string continueInput = Console.ReadLine();
    return continueInput.ToLower() == "n";
  }

}