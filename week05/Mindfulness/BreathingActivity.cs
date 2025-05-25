class BreathingActivity : Activity
{

  private int _breathInTime = 4;
  private int _breathOutTime = 6;
  private int interval = 2;
  private int _totalBreaths = 3;

  private void Breathe(string direction)
  {
    int breathTime = direction == "in" ? _breathInTime : _breathOutTime;
    Console.Write($"breathe {direction} for {breathTime} seconds");
    List<string> inSpinner = new List<string>();
    for (int i = 1; i <= breathTime; i++)
    {
      string dots = new string('.', i);
      inSpinner.Add(dots);
    }
    base.Spin(breathTime * 1000, 1000, inSpinner);
    Console.Write("\n");
  }

  public void Run()
  {
    Console.Write("running breathing activity...\n");
    while (_totalBreaths > 0)
    {
      Breathe("in");
      Console.Write($"hold for {interval} seconds");
      base.Spin(interval * 1000);
      Console.Write("\n");
      Breathe("out");
      _totalBreaths--;
    }
    Console.Write("breathing activity done");
    Console.Clear();
  }
}