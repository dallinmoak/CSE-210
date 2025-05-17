using System;
using System.Numerics;

class Program
{
  static void Main(string[] args)
  {
    List<Video> vids = new List<Video>();

    Video v1 = new Video("Fundamentals in Underwater Basket Weaving", "Barry Weaver", 120);
    v1.AddComment("This is a great intro to the topic. very well explained", "Frodo Baggins");
    v1.AddComment("Could have done without the racial slurs", "Samwise Gamgee");
    v1.AddComment("We hates it😍", "Gollum");
    v1.AddComment("I love this video😡", "Smeagol");
    vids.Add(v1);

    Video v2 = new Video("Advanced Underwater Basket Weaving", "Barium Weaverton", 240);
    v2.AddComment("I learned a great deal I didnt know about basket weaving", "Rand Al'Thor");
    v2.AddComment("Already knew all this stuff", "Lews Therin Telamon");
    v2.AddComment("Fake news, seaweed is not UBA authorized material", "Egwene al'Vere");
    v2.AddComment("Impossible. I have never seen a basket in the ocean", "Mat Cauthon");
    vids.Add(v2);

    Video v3 = new Video("Underwater Basket Weaving: A Cultural Analysis", "Bartimiton Weaverlithicius, IV", 60);
    v3.AddComment("good insights on austrailian basket weaving contests", "Ned Stark");
    v3.AddComment("Great family bonding activity", "Jaime Lannister");
    v3.AddComment("Where I'm from, mixed gender teams are punnishable by death", "Daenerys Targaryen");
    v3.AddComment("I once killed a man for weaving a basket in front of my mother 💁", "Sansa Stark");
    vids.Add(v3);

    foreach (Video v in vids)
    {
      Console.Write(v.GetDetails());
      Console.Write($"{v.GetCommentCount()} comment(s)\n");
      Console.Write(v.GetComments());
      Console.Write("-----------------\n");
    }
  }
}