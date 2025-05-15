class Word
{
  public Word(string content)
  {
    this._content = content;
    this._hidden = false;
  }

  private string _content;
  private bool _hidden;

  public string GetDisplayString()
  {
    if (this._hidden)
    {
      string hidden = "";
      foreach (char c in this._content)
      {
        hidden += "_";
      }
      return hidden;
    }
    else
    {
      return this._content;
    }
  }

  public void Hide()
  {
    this._hidden = true;
  }

  public bool IsHidden()
  {
    return this._hidden;
  }
}