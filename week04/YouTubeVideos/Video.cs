class Video
{
  private string _title;
  private string _author;
  private int _length;
  private List<Comment> _comments;
  public Video(string title, string author, int length)
  {
    _title = title;
    _author = author;
    _length = length;
    _comments = new List<Comment>();
  }

  public void AddComment(string comment, string author)
  {
    _comments.Add(new Comment(comment, author));
  }
  public string GetDetails()
  {
    return $"Title: {_title}\nAuthor: {_author}\nRuntime: {_length} seconds\n";
  }
  public int GetCommentCount()
  {
    return _comments.Count;
  }
  public string GetComments()
  {
    string commentList = "Comments:\n";
    foreach (Comment c in _comments)
    {
      commentList += $"  {c.GetDetails()}";
      commentList += "  ---------------\n";
    }
    return commentList;
  }
}