class Journal
{
  public Journal(string loadPath = null)
  {
    this._entries = loadPath == null ? new List<string>() : this.Load(loadPath);
    this._loadPath = loadPath;
  }
  private List<string> _entries;
  private string _loadPath;
  private List<string> Load(string loadPath)
  {
    return new List<string>();
  }
  public void PrintEntries()
  {
    Console.Write("here's the entries\n");
  }
  public bool HasEntries()
  {
    return this._entries.Count > 0;
  }
  public string GetLoadPath()
  {
    if (this._loadPath == null)
    {
      return null;
    }
    return this._loadPath;
  }
}