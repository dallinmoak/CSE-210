class Swim : ActivityBase
{
  public Swim(string type, double distance, int duration) : base(type, distance, duration) { }

  protected override double GetDistance(string preferredUnit)
  {
    return base.GetDistanceBasic() * 20;
  }

  public override string GetSummary(string preferredUnit)
  {
    string typeClause = $"Type: {_type}, ";

    string distanceClause = $"Distance: {base.GetDistanceBasic(preferredUnit):F2}{preferredUnit}, ";
    string lapsClause = $"that's {this.GetDistance(preferredUnit):F2} laps. ";
    string durationClause = $"Duration: {base.getDuration()}, ";
    string paceClause = $"Pace: {base.getPace(preferredUnit)}";
    return "swim summary: " +
           typeClause +
           distanceClause +
           lapsClause +
           durationClause +
           paceClause;
  }
}