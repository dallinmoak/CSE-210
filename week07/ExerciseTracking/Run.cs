class Run : ActivityBase
{
  public Run(string type, double distance, int duration) : base(type, distance, duration) { }

  public override string GetSummary(string preferredUnit)
  {
    string typeClause = $"Type: {_type}, ";
    string distanceClause = $"Distance: {base.getDistance(preferredUnit)}, ";
    string durationClause = $"Duration: {base.getDuration()}, ";
    string paceClause = $"Pace: {base.getPace(preferredUnit)}";
    return "run summary: " +
           typeClause +
           distanceClause +
           durationClause +
           paceClause;
  }
}