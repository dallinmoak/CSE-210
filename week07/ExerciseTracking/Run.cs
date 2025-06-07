class Run : ActivityBase
{
  public Run(string type, double distance, int duration) : base(type, distance, duration) { }

  public override string GetSummary(string preferredUnit)
  {
    return "run summary";
  }
}