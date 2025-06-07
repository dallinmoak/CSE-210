class Run : ActivityBase
{
  public Run(string type, double distance, int duration) : base(type, distance, duration) { }

  protected override double GetDistance(string preferredUnit)
  {
    return base.GetDistanceBasic(preferredUnit);
  }

  public override string GetSummary(string preferredUnit)
  {
    string typeClause = $"Type: {_type}, ";
    string distanceClause = $"Distance: {base.GetDistanceBasic(preferredUnit):F2}{preferredUnit}, ";
    string durationClause = $"Duration: {base.getDuration()}, ";
    string paceClause = $"Pace: {base.getPace(preferredUnit)}";
    return "run summary: " +
           typeClause +
           distanceClause +
           durationClause +
           paceClause;
  }
}