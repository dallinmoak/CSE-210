class ListingActivity : Activity
{
  public void Run()
  {
    Console.Write("running listing activity...\n");
    base.Spin();
    System.Threading.Thread.Sleep(2000);
    Console.Write("listing activity done");
    Console.Clear();
  }
}