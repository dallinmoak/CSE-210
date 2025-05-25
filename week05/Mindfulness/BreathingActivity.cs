class BreathingActivity : Activity
{
  public void Run()
  {
    Console.Write("running breathing activity...\n");
    base.Spin();
    System.Threading.Thread.Sleep(2000);
    Console.Write("breathing activity done");
    Console.Clear();
  }
}