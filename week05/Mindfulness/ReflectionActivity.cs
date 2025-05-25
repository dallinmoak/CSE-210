class ReflectionActivity : Activity
{
  public void Run()
  {
    Console.Write("running reflection activity...\n");
    base.Spin(2000);
    Console.Write("reflection activity done");
    Console.Clear();
  }
}