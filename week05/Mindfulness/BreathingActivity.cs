class BreathingActivity : Activity
{
  public void Run()
  {
    Console.Write("running breathing activity...\n");
    int breathInTime = 4;
    Console.Write($"breathe in for {breathInTime} seconds");
    List<string> inSpinner = new List<string>();
    for (int i = 1; i <= breathInTime; i++)
    {
      string dots = new string('.', i);
      inSpinner.Add(dots);
    }
    Console.Write("\n\ninSpinner:");
    int index = 0;
    foreach (string dot in inSpinner)
    {
      Console.Write(dot);
      index++;
      if (index < inSpinner.Count)
      {
        Console.Write(", ");
      }
    }
    Console.Write("\n\n");
    Console.ReadLine();
    base.Spin(breathInTime * 1000, 1000, inSpinner);
    base.Spin(2000);
    Console.Write("breathing activity done");
    Console.Clear();
  }
}