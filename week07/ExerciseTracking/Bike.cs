class Bike : ActivityBase
{

  private static int _armstrongTime = 295512000;
  private static double _armstrongDistance = 3278.0;

  public Bike(string type, double distance, int duration) : base(type, distance, duration) { }

  protected override double GetDistance(string preferredUnit)
  {
    // distance in km as a % of the '02 tour de france
    return base._distance / _armstrongDistance * 100;
  }

  public override string GetSummary(string preferredUnit)
  {
    string typeClause = $"Type: {_type}, ";
    string distanceClause = $"Distance: {base.GetDistanceBasic(preferredUnit):F2}{preferredUnit}, ";
    string durationClause = $"Duration: {base.getDuration()}, ";
    string armstrongClause = $"that's {this.GetDistance(preferredUnit):F2}% of the distance Lance Armstrong rode in the '02 Tour de France. ";
    string paceClause = $"Pace: {base.getPace(preferredUnit)}";
    return "run summary: " +
           typeClause +
           distanceClause +
           armstrongClause +
           durationClause +
           paceClause;
  }
}