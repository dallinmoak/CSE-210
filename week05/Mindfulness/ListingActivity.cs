class ListingActivity : Activity
{
  public void Run()
  {
    Console.Write("running listing activity...\n");
    base.Spin(2000);
    Console.Write("listing activity done");
    Console.Clear();
  }
}