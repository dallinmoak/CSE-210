class Scripture
{
  public Scripture()
  {
    this.Init();
  }

  public Scripture(string content, Reference reference)
  {
    this.SetContent(content);
    this._reference = reference;
  }

  private string _rawContent;
  private List<Word> _content = new List<Word>();
  private Reference _reference;
  public bool allWordsHidden = false;
  private void Init()
  {
    Console.Write("Enter the content of the scripture: ");
    this.SetContent(Console.ReadLine());
    this._reference = new ReferenceGetter().Get();
  }

  private void SetContent(string content)
  {
    this._rawContent = content;
    string[] words = this._rawContent.Split(' ');
    foreach (string word in words)
    {
      this._content.Add(new Word(word));
    }
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

  private void HideWord()
  {
    int target = new Random().Next(0, this._content.Count);
    int attempts = 1;
    // loop through the list until a visible word is found, if all are hidden, set AllWordsHidden to true
    while (attempts < this._content.Count)
    {
      attempts += 1;
      if (this._content[target].IsHidden())
      {
        target += 1;
        if (target >= this._content.Count)
        {
          target = 0;
        }
      }
      else
      {
        this._content[target].Hide();
        return;
      }
    }
    // all words but one are hidden
    this._content[target].Hide();
    // now, all words are hidden
    this.allWordsHidden = true;
  }

  public void HideWords()
  {
    int count = new Random().Next(2, 3);
    for (int i = 0; i < count; i++)
    {
      this.HideWord();
    }
  }
}
