using System;
using System.Collections.Generic;

class Program
{
  private class Job(string company, string title, int startYear, int endYear)
  {
    private string _company = company;
    private string _title = title;
    private int _startYear = startYear;
    private int _endYear = endYear;

    public string DisplayJob()
    {
      return $"{_title} ({_company})  {_startYear}-{_endYear}";
    }
  }

  private class Resume(string name, List<Job> jobs)
  {
    private string _name = name;
    private List<Job> _jobs = jobs;

    public string DisplayResume()
    {
      string resume = $"Name {_name}\nJobs:\n";
      foreach (Job job in _jobs)
      {
        resume += job.DisplayJob() + "\n";
      }
      return resume;
    }
  }
  static void Main(string[] args)
  {
    List<Job> myJobs = [
      new Job("Microsoft", "Software Engineer", 2010, 2015),
      new Job("Google", "Senior Software Engineer", 2015, 2020),
      new Job("Amazon", "Principal Software Engineer", 2020, 2025)
    ];
    Resume myResume = new("John Doe", myJobs);
    Console.WriteLine(myResume.DisplayResume());
  }
}