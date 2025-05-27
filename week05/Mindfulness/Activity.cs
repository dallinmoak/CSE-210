class Activity
{

  protected string _type;
  protected string _description;
  protected int _duration;

  protected void PreRun()
  {
    this.DisplayWelcome();
    this.GetDuration();
    Console.Clear();
    Console.Write("Ok, get ready!");
    this.Spin(2000);
    Console.Clear();
    Console.Write("Here we go");
    this.Spin(2000);
    Console.Clear();
  }

  protected void PostRun()
  {
    Console.Clear();
    Console.Write("good job, you did the activity\n");
    Console.Write($"time spent: {this._duration} seconds. all done. ");
    this.Spin(4000);
    Console.Clear();
  }

  private void DisplayWelcome()
  {
    Console.Write($"Welcome to the {this._type} Activity.\n");
    Console.Write($"{this._description}\n");
  }

  private void GetDuration()
  {
    bool validInput = false;
    while (!validInput)
    {
      Console.Write("How many seconds? ");
      string input = Console.ReadLine();
      if (int.TryParse(input, out int duration) && duration > 0)
      {
        Console.Write($"You chose a duration of {duration} seconds.\n");
        this._duration = duration;
        validInput = true;
        break;
      }
      Console.Write("Invalid input\n");
    }
  }

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