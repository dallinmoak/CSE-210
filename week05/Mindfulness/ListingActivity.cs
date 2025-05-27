class ListingActivity : Activity
{

  private List<string> _prompts;

  public ListingActivity()
  {
    this._type = "Listing";
    this._description = "This activity is where you make a list of things about a topic. when prompted, type the list items separated by newlines. The last newline you send past the activity duration will end the activity.";
    base.PreRun();
    this._prompts = new List<string>
    {
      "List all the members of the Q Continuum you can think of",
      "List all the Klingon words you know",
      "List the name and serial number of every Starfleet ship you know",
      "List the episodes in TNG in which Security Chief Tasha Yar dies (hint: it's more than 1)",
    };
  }

  public void Run()
  {
    Console.Write("this is the listing activity ");
    base.Spin(2000);
    Console.Write("that's all for listing\n");
    base.PostRun();
  }
}