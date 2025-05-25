class Activity
{
  protected void Spin(int mils, int frameRate = 100, List<string> spinner = null)
  {
    //default spinner:
    if (spinner == null)
    {
      spinner = new List<string> { "|", "/", "-", "\\" };
    }
    int frames = mils / frameRate;
    int count = 0;
    while (count < frames)
    {
      string currentSpinner = spinner[count % spinner.Count];
      Console.Write(currentSpinner);
      Thread.Sleep(frameRate);
      for (int i = 0; i < currentSpinner.Length; i++)
      {
        Console.Write("\b \b");
      }
      count++;
    }
  }
}