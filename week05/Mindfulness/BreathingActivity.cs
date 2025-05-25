class BreathingActivity : Activity
{
  public void Run()
  {
    Console.Write("running breathing activity...\n");
    base.Spin(2000);
    Console.Write("breathing activity done");
    Console.Clear();
  }
}