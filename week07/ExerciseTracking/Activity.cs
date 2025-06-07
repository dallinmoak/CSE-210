abstract class ActivityBase
{
  protected string _type;
  protected double _distance;
  protected int _duration;

  protected string getDuration()
  {
    TimeSpan interval = TimeSpan.FromMilliseconds(_duration);
    string hoursRaw = $"{(int)interval.TotalHours:D2}";
    string hours = hoursRaw == "00" ? "" : $"{hoursRaw}:";
    string minutesRaw = $"{interval.Minutes:D2}";
    string minutes = minutesRaw == "00" ? "" : $"{minutesRaw}:";
    if (interval.Hours == 0 && interval.Minutes == 0)
    {
      return $"{interval.Seconds:D2} s";
    }
    else if (interval.Hours == 0)
    {
      return $"{minutes}{interval.Seconds:D2} (mm:ss)";
    }
    else if (interval.Minutes == 0)
    {
      return $"{hours}{interval.Seconds:D2} (hh:ss)";
    }
    return $"{hours}{minutes}{interval.Seconds:D2} (hh:mm:ss)";
  }

  public ActivityBase(string type, double distance, int duration)
  {
    this._type = type;
    this._distance = distance;
    this._duration = duration;
  }
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