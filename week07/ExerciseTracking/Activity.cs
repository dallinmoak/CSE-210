abstract class ActivityBase
{
  protected string _type;
  protected double _distance;
  protected int _duration;

  static private double _mileToKilometer = 0.621371;

  public ActivityBase(string type, double distance, int duration)
  {
    this._type = type;
    this._distance = distance;
    this._duration = duration;
  }

  protected string getDuration(TimeSpan sp = new TimeSpan())
  {
    TimeSpan interval;
    // an empty TimeSpan param assumes the method should use the activity duration
    if (sp == new TimeSpan())
    {
      interval = TimeSpan.FromMilliseconds(_duration);
    }
    else
    {
      interval = sp;
    }
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

  protected String getPace(string preferredUnit = "km")
  {
    double unitDistance = this._distance;
    if (preferredUnit == "mi")
    {
      unitDistance *= _mileToKilometer;
    }
    double unitPace = (double)this._duration / unitDistance;
    TimeSpan interval = TimeSpan.FromMilliseconds(unitPace);
    string unitDuration = getDuration(interval);
    double unitSpeed = 3600000 / unitPace;
    return $"{unitDuration:F2}/{preferredUnit}. Speed: {unitSpeed:F2} {preferredUnit}/h";
  }

  protected string getDistance(string preferredUnit = "km")
  {
    double unitDistance = this._distance;
    if (preferredUnit == "mi")
    {
      unitDistance *= _mileToKilometer;
    }
    return $"{unitDistance:F2} {preferredUnit}";
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