class Memorizer
{
  private Scripture _scripture;
  public void PromptForContentAndRef()
  {
    Console.Write("Do you want to [E]nter a new scripture or [G]enerate one? (E/g): ");
    string input = Console.ReadLine();
    if (input.ToLower() == "g")
    {
      string content = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
      string book = "John";
      int chapter = 3;
      int startVerse = 16;
      int endVerse = 16;
      Reference reference = new Reference(book, chapter, startVerse, endVerse);
      this._scripture = new Scripture(content, reference);
      return;
    }
    this._scripture = new Scripture();
  }

  public void Display(bool clear = true)
  {
    if (clear)
    {
      Console.Clear();
    }
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
    Console.Clear();
    Console.Write("Ok, get a good look at the scripture.\n");
    this.Display(clear: false);
    Console.Write("Press Enter to start hiding words: ");
    Console.ReadLine();
    bool allWordsHidden = false;
    while (!allWordsHidden)
    {
      this._scripture.HideWords();
      allWordsHidden = this._scripture.allWordsHidden;
      Console.Clear();
      Console.Write("Ok, get a good look at the scripture.\n");
      this.Display(clear: false);
      if (allWordsHidden)
      {
        Console.WriteLine("all words hidden");
        break;
      }
      Console.Write("Press Enter to continue or type 'quit' to quit: ");
      string input = Console.ReadLine();
      if (input.ToLower() == "quit")
      {
        Console.WriteLine("you gave up");
        gaveUp = true;
        break;
      }
    }
    return gaveUp;
  }

  public void Congratulate()
  {
    Console.WriteLine("Congratulations! You've memorized the scripture.");
  }

}