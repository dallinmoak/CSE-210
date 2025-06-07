class ActivityTracker
{

  private string _ownerName;
  private string _preferredUnit;
  private List<Activity> _activities;

  public ActivityTracker(string ownerName, string preferredUnit, List<Activity> activities)
  {
    this._ownerName = ownerName;
    this._preferredUnit = preferredUnit;
    this._activities = activities;
  }

  public void PrintSummary()
  {
    Console.Write($"Here's the activity set for {_ownerName} in {_preferredUnit}:\n");
    foreach (Activity activity in _activities)
    {
      Console.WriteLine(activity.GetSummary(_preferredUnit));
    }
  }
}