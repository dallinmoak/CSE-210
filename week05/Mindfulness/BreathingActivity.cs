class BreathingActivity : Activity
{

  private int _breathInTime = 4;
  private int _breathOutTime = 6;
  private int interval = 2;
  private int _totalBreaths;

  public BreathingActivity()
  {
    this._type = "Breathing";
    base.PreRun();
    // I'm calculating the number of breaths that can be done, rounding up to the nearest breath
    this.ComputeTotalBreaths();
  }

  private void ComputeTotalBreaths()
  {
    int breathTime = _breathInTime + _breathOutTime + interval;
    Console.Write($"computing total breaths. duration: {this._duration}\n");
    double breathsDouble = (double)this._duration / breathTime;
    int breaths = (int)Math.Ceiling(breathsDouble);
    this._totalBreaths = breaths;
  }

  private void Breathe(string direction)
  {
    int breathTime = direction == "in" ? _breathInTime : _breathOutTime;
    string breathPrompt = $"breathe {direction} for {breathTime} seconds ";
    if (direction == "hold")
    {
      breathPrompt = $"hold for {breathTime} seconds ";
      breathTime = interval;
    }
    Console.Write(breathPrompt);
    List<string> inSpinner = new List<string>();
    for (int i = breathTime; i >= 1; i--)
    {
      string countDown = i.ToString();
      inSpinner.Add(countDown);
    }
    base.Spin(breathTime * 1000, 1000, inSpinner);
    Console.Write("0");
    Console.Write("\n");
  }

  public void Run()
  {
    while (_totalBreaths > 0)
    {
      Breathe("in");
      Breathe("hold");
      Breathe("out");
      _totalBreaths--;
    }
    Console.Clear();
  }
}