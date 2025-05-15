class Memorizer
{
  private Scripture _scripture;
  public void PromptForContentAndRef()
  {
    this._scripture = new Scripture();
  }

  public void Display()
  {
    Console.Clear();
    Console.WriteLine(this._scripture.GetDisplayString());
  }

  public bool PromptToMemorize()
  {
    Console.Write("Do you want to memorize this scripture? (Y/n): ");
    string input = Console.ReadLine();
    if (input.ToLower() == "n")
    {
      Console.WriteLine("You've opted out of memorizing this scripture.");
      return false;
    }
    return true;
  }

  public bool Memorize()
  {
    bool gaveUp = false;
    Console.Write("Ok, get a good look at the scripture.\n");
    Console.Write("Press Enter when you are ready to start memorizing.\n");
    Console.ReadLine();
    bool allWordsHidden = false;
    while (!allWordsHidden)
    {
      allWordsHidden = this._scripture.allWordsHidden;
      Console.WriteLine($"starting another iteration. All words hidden: {allWordsHidden}");
      System.Threading.Thread.Sleep(1000);
      if (allWordsHidden)
      {
        break;
      }
      Console.Clear();
      Console.WriteLine(this._scripture.GetDisplayString());
      Console.Write("Press Enter to hide a word, or type 'quit' to stop memorizing: ");
      string input = Console.ReadLine();
      if (input.ToLower() == "quit")
      {
        allWordsHidden = true;
        Console.WriteLine("You gave up.");
        gaveUp = true;
        break;
      }
      else
      {
        Console.WriteLine("some words are still visible.");
        this._scripture.HideWord();
      }
    }
    return gaveUp;
  }

  public void Congratulate()
  {
    Console.WriteLine("Congratulations! You've memorized the scripture.");
  }

}