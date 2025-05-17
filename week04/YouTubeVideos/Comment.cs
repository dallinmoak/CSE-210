class Comment
{
  private string _author;
  private string _text;

  public Comment(string text, string author)
  {
    _text = text;
    _author = author;
  }
  public string GetDetails()
  {
    return $"{_author}: {_text}\n";
  }
}