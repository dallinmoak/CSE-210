class ListingActivity : Activity
{

  public ListingActivity()
  {
    this._type = "Listing";
    this._description = "This activity is where you make a list of things about a topic.";
    base.PreRun();
  }

  public void Run()
  {
    Console.Write("this is the listing activity ");
    base.Spin(2000);
    Console.Write("that's all for listing\n");
    base.PostRun();
  }
}