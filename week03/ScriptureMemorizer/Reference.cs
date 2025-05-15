class Reference
{
  private string _book;
  private int _chapter;
  private int _startVerse;
  private int? _endVerse;
  public Reference(string book, int chapter, int startVerse, int? endVerse = null)
  {
    this._book = book;
    this._chapter = chapter;
    this._startVerse = startVerse;
    this._endVerse = endVerse;
  }

  public string GetDisplayString()
  {
    return this._book + " " + this._chapter + ":" + this._startVerse + (this._endVerse.HasValue ? "-" + this._endVerse.Value : "");
  }

}


class ReferenceGetter
{
  public ReferenceGetter()
  {
    this.Init();
  }

  private Reference _reference;

  private void Init()
  {
    Console.Write("Enter the book of the scripture: ");
    string book = Console.ReadLine();
    int chapter = GetUserInt("Enter the chapter of the scripture: ");
    int startVerse = GetUserInt("Enter the start verse of the scripture: ");
    int endVerse = GetUserInt("Enter the end verse of the scripture (same as start verse if not applicable): ");
    if (endVerse == startVerse)
    {
      this._reference = new Reference(book, chapter, startVerse);
    }
    else
    {
      this._reference = new Reference(book, chapter, startVerse, endVerse);
    }
  }

  private int GetUserInt(string prompt)
  {
    Console.Write(prompt);
    string input = Console.ReadLine();
    int result;
    while (!int.TryParse(input, out result))
    {
      Console.Write("Invalid input. Please enter a number: ");
      input = Console.ReadLine();
    }
    return result;
  }

  public Reference Get()
  {
    return this._reference;
  }
}