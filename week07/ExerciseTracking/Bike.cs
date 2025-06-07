class Bike : ActivityBase
{
  public Bike(string type, double distance, int duration) : base(type, distance, duration) { }

  public override string GetSummary(string preferredUnit)
  {
    return "bike summary";
  }
}