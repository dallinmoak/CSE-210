class Run : ActivityBase
{
  public Run(string type, double distance, int duration) : base(type, distance, duration) { }

  public override string GetSummary(string preferredUnit)
  {
    string typeClause = $"Type: {_type}, ";
    string distanceClause = $"Distance: {_distance} {preferredUnit}, ";
    string durationClause = $"Duration: {base.getDuration()}";
    return "run summary: " +
           typeClause +
           distanceClause +
           durationClause;
  }
}