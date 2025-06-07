using System;
using System.Diagnostics;

class Program
{
  static void Main(string[] args)
  {
    // This is the plan: I make an activity tracker that creates 3 activites of type run, swim, and bike, with their respective distances and durations.
    // each of the child class defs for Activity (Run, Swim and Bike) will implement their own version of a GetSummary method that will return a summary relevant to that activity give the values of distance and duration provided, the type of activity, and the tracker's preferred unit of measurement.

    //just to show that the pace isn't hardcoded, I added a 4 minute mile run

    Console.Write("creating an activity tracker that has a 4km run of 15 minutes, a 400m swim of 8 minutes, and a 14km bike ride of 33 minutes, 36 seconds, where the printed unit is km and the owner is Dallin Moak.....\n");
    ActivityTracker t1 = new ActivityTracker(
      ownerName: "Dallin Moak",
      preferredUnit: "km",
      activities: new List<Activity>
      {
        // all activity constructors takes a string activity type, a double (kilometers) distance, and an int (milliseconds) duration
        new Activity(
          // assume a 16kph speed for running
          type: "run",
          distance: 4,
          duration: 900000
        ),
        new Activity(
          // assume a 3kph speed for swimming
          type: "swim",
          distance: 0.4,
          duration: 480000
        ),
        new Activity(
          // assume a 25kph speed for biking
          type: "bike",
          distance: 14.0,
          duration: 2016000
        ),
        // 4 minute mile
        new Activity(
          type: "run",
          distance: 1.609344,
          duration: 240000
        )
      }
    );
    t1.PrintSummary();
  }
}