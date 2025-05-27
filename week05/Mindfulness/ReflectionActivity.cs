class ReflectionActivity : Activity
{

  // I figure this is a justifiable use case for a record to for the 1 prompt to many follow-up relationship.
  private record ReflectionPrompt(string Question, List<string> FollowUps);
  private List<ReflectionPrompt> _prompts;

  private int _totalPrompts;
  private int _firstInterval = 2;
  private int _secondInterval = 5;

  public ReflectionActivity()
  {
    this._type = "Reflection";
    this._description = "Now you get to read some stuff and think about it. You don't have to write the answers tho. but if you do, use paper not the terminal.";
    base.PreRun();
    this._prompts = new List<ReflectionPrompt>
    {
      new ReflectionPrompt("Think of the best TV show ever", new List<string>
      {
        "How many seasons did it have?",
        "was it a sitcom?",
        "The correct answer is Star Trek: The Next Generation. Why didn't you think of it?"
      }),
      new ReflectionPrompt("Think of the US President who least resembles Jean Luc Picard", new List<string>
      {
        "What criteria did you use? appearance or vibe?",
        "If Al Gore had won in '00 would you have changed your answer?",
        "Consider the same question for James T. Kirk."
      }),
      new ReflectionPrompt("Consider the thing you dislike most about language bots", new List<string>
      {
        "Is it a common bias you disagree with?",
        "Is it the fact that they think they know what you want?",
        "Is it ethical to hate on a bot that can pass the Turing test? What would Data say?",
      })
    };
    this._totalPrompts = (int)Math.Ceiling((double)this._duration / (_firstInterval + _secondInterval));
  }

  private ReflectionPrompt GetRandomPrompt()
  {
    int promptIndex = new Random().Next(_prompts.Count);
    return _prompts[promptIndex];
  }

  private string GetRandomFollowUp(ReflectionPrompt prompt)
  {
    int followUpIndex = new Random().Next(prompt.FollowUps.Count);
    return prompt.FollowUps[followUpIndex];
  }

  public void Run()
  {
    while (this._totalPrompts > 0)
    {
      ReflectionPrompt prompt = GetRandomPrompt();
      Console.Write($"{prompt.Question}\n");
      Console.Write("Got it? ");
      base.Spin(_firstInterval * 1000);
      Console.Write("Good. Now consider this:\n");
      string followUp = GetRandomFollowUp(prompt);
      Console.Write($"{followUp}\n");
      base.Spin(_secondInterval * 1000);
      Console.Clear();
      Console.Write("Ok, next prompt\n");
      this._totalPrompts--;
    }
    base.PostRun();
  }
}