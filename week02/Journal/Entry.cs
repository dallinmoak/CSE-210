class Entry
{
  public Entry() // from user action
  {
    this._date = DateTime.Now.ToString("yyyy-MM-dd");
    this._promptText = this.generatePromptText();
    this._content = this.Prompt();
  }
  public Entry(string content, string promptText, string date) // from file
  {
    this._content = content;
    this._promptText = promptText;
    this._date = date;
  }
  private string _content;
  private string _promptText;
  private string _date;

  private string generatePromptText()
  {
    List<string> possiblePrompts = [
            "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
          ];
    return possiblePrompts[new Random().Next(0, possiblePrompts.Count)];
  }
  private string Prompt()
  {
    Console.WriteLine(this._promptText);
    string? content = Console.ReadLine();
    if (string.IsNullOrEmpty(content))
    {
      Console.WriteLine("No content entered. Please try again.");
      return Prompt();
    }
    return content;
  }
  public string GetFormmated()
  {
    return $"Date: {this._date}\nPrompt:{this._promptText}\nContents: {this._content}\n______________________\n";
  }
}