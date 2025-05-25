class ReflectionActivity : Activity
{
  public void Run()
  {
    Console.Write("running reflection activity...\n");
    base.Spin();
    System.Threading.Thread.Sleep(2000);
    Console.Write("reflection activity done");
    Console.Clear();
  }
}