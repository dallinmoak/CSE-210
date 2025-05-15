class Scripture
{
  public Scripture()
  {
    this.Init();
  }

  private string _rawContent;
  private List<Word> _content = new List<Word>();
  private Reference _reference;
  public bool allWordsHidden = false;
  private void Init()
  {
    Console.Write("Enter the content of the scripture: ");
    this._rawContent = Console.ReadLine();
    string[] words = this._rawContent.Split(' ');
    foreach (string word in words)
    {
      this._content.Add(new Word(word));
    }
    this._reference = new ReferenceGetter().Get();
  }

  public string GetDisplayString()
  {
    return this._reference.GetDisplayString() + ":\n" + this.getWords();
  }

  private string getWords()
  {
    string result = "";
    foreach (Word word in this._content)
    {
      result += word.GetDisplayString() + " ";
    }
    return result;
  }

  public void HideWord()
  {
    int target = new Random().Next(0, this._content.Count);
    int attempts = 0;
    // loop through the list until a visible word is found, if all are hidden, set AllWordsHidden to true
    while (attempts < this._content.Count)
    {
      if (this._content[target].IsHidden())
      {
        target += 1;
        if (target >= this._content.Count)
        {
          target = 0;
        }
        attempts += 1;
      }
      else
      {
        this._content[target].Hide();
        return;
      }
    }
    // all words but one are hidden
    Console.WriteLine("All words are hidden.");
    this._content[target].Hide();
    // now, all words are hidden
    this.allWordsHidden = true;
  }
}
