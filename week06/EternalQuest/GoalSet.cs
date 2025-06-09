using System.IO;

class GoalSet
{
  public string location;
  public List<Goal> goals;
  public int totalScore;
  private int _activeGoalIndex = -1;

  public GoalSet(string location)
  {
    this.location = location;
    bool foundIt = File.Exists(location);
    if (foundIt)
    {
      this.Load(location);
      this.UpdateTotalScore();
    }
    else
    {
      this.goals = new List<Goal>();
      this.totalScore = 0;
    }
  }

  public void Save()
  {
    using (StreamWriter outFile = new StreamWriter(this.location))
    {
      outFile.WriteLine(this.location);
      foreach (Goal g in this.goals)
      {

        outFile.WriteLine(g.GoalToString());
      }
    }
  }

  public void Load(string location)
  {
    // read the contents of a file at location and populate the goals list with the goals found in the file, setting the totalScore accordingly
    string[] lines = File.ReadAllLines(location);
    char delimiter = '~';
    this.location = lines[0].Trim();
    string[] goalsRaw = [.. lines.Skip(1)];
    this.goals = new List<Goal>();
    Goal g = null;
    foreach (string goalRaw in goalsRaw)
    {
      Console.WriteLine($"loading goal: {goalRaw}");
      string[] parts = goalRaw.Trim().Split(delimiter);
      string goalType = parts[0].Trim();
      string label = parts[1].Trim();
      int currentValue = int.Parse(parts[2].Trim());
      if (goalType == "SimpleGoal")
      {
        int completionPoints = int.Parse(parts[3].Trim());
        g = new SimpleGoal(
         label,
         currentValue,
         completionPoints
       );
      }
      else if (goalType == "EternalGoal")
      {
        int completionPoints = int.Parse(parts[3].Trim());
        g = new EternalGoal(
         label,
         currentValue,
         completionPoints
       );
      }
      else if (goalType == "IteratingGoal")
      {
        int completionPoints = int.Parse(parts[3].Trim());
        int completedIterations = int.Parse(parts[4].Trim());
        int iterations = int.Parse(parts[5].Trim());
        int pointsPerIteration = int.Parse(parts[6].Trim());
        g = new IteratingGoal(
         label,
         currentValue,
         completionPoints,
         completedIterations,
         iterations,
         pointsPerIteration
       );
      }
      this.goals.Add(g);
    }

  }

  public void AddGoal(string header)
  {
    Console.Clear();
    if (header != "")
    {
      Console.Write($"{header}\n");
    }
    Goal g = new GoalMaker().Make();
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
    this.UpdateTotalScore();
    Console.Write("stats:\n");
    Console.Write($" total score: {this.totalScore}\n");
  }

  private void UpdateTotalScore()
  {
    this.totalScore = 0;
    foreach (Goal g in this.goals)
    {
      this.totalScore += g.getCurrentScore();
    }
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
      Console.Write("wanna save? (Y/n): ");
      string saveInput = Console.ReadLine();
      if (saveInput.ToLower() != "n")
      {
        this.Save();
        Console.Write("goalset saved.\n");
      }
      else
      {
        Console.Write("goalset not saved.\n");
      }
      Thread.Sleep(1000);
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
    this.UpdateTotalScore();
    Console.Write("Do you want to continue working on this goal set? (Y/n): ");
    string continueInput = Console.ReadLine();
    if (continueInput.ToLower() == "n")
    {
      Console.Write("wanna save? (Y/n): ");
      string saveInput = Console.ReadLine();
      if (saveInput.ToLower() != "n")
      {
        this.Save();
        Console.Write("goalset saved.\n");
      }
      else
      {
        Console.Write("goalset not saved.\n");
      }
      Thread.Sleep(1000);
      return true;
    }
    else
    {
      return false;
    }
  }

}