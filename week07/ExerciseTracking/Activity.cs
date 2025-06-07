abstract class ActivityBase
{
  public ActivityBase(string type, double distance, int duration) { }
  public abstract string GetSummary(string preferredUnit);
}


// for readablility im going to make the actvity class more of a factory clas for ActivityBase and its children, but it can be used as the activity tracker's interface with activities.
class Activity
{
  private ActivityBase this_activity;

  public Activity(string type, double distance, int duration)
  {
    switch (type)
    {
      case "run":
        this_activity = new Run(type, distance, duration);
        break;
      case "swim":
        this_activity = new Swim(type, distance, duration);
        break;
      case "bike":
        this_activity = new Bike(type, distance, duration);
        break;
      default:
        throw new ArgumentException("Invalid activity type");
    }
  }
  public string GetSummary(string preferredUnit)
  {
    return this_activity.GetSummary(preferredUnit);
  }
}