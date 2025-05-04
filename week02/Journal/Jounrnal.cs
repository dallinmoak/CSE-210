class Journal
{
  public Journal(string? loadPath = null)
  {
    this._entries = loadPath == null ? new List<Entry>() : this.Load(loadPath);
    this._loadPath = loadPath;
  }
  private List<Entry> _entries;
  private string? _loadPath;
  private List<Entry> Load(string loadPath)
  {
    if (File.Exists(loadPath))
    {
      string[] rows = File.ReadAllLines
      (loadPath);
      List<Entry> entries = new List<Entry>();
      foreach (string row in rows)
      {
        string[] cols = row.Split(';');
        string date = cols[0];
        string promptText = cols[1];
        string content = cols[2];
        Entry newEntry = new Entry(content, promptText, date);
        entries.Add(newEntry);
      }
      return entries;
    }
    else
    {
      throw new Exception("File not found");
    }
  }
  public void PrintEntries()
  {
    if (this._entries.Count == 0)
    {
      Console.WriteLine("No entries found.");
      return;
    }
    foreach (Entry entry in this._entries)
    {
      Console.WriteLine($"{entry.GetFormmated()}\n");
    }
  }
  public bool HasEntries()
  {
    return this._entries.Count > 0;
  }
  public string? GetLoadPath()
  {
    return this._loadPath;
  }
  public void AddEntry()
  {
    this._entries.Add(new Entry());
  }
}