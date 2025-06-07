class Swim : ActivityBase
{
  public Swim(string type, double distance, int duration) : base(type, distance, duration) { }

  public override string GetSummary(string preferredUnit)
  {
    return "swim summary";
  }
}