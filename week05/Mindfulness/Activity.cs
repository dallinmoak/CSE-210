class Activity
{
  protected void Spin(int mils)
  {
    List<string> spinner = ["|", "/", "-", "\\"];
    int frameRate = 100;
    int frames = mils / frameRate;
    int count = 0;
    while (count < frames)
    {
      Console.Write(spinner[count % spinner.Count]);
      Thread.Sleep(frameRate);
      Console.Write("\b \b");
      count++;
    }
  }
}