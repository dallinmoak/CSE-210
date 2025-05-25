class ReflectionActivity : Activity
{
  public ReflectionActivity()
  {
    this._type = "Reflection";
    this._description = "Now you get to read some stuff and think about it.";
    base.PreRun();
  }

  public void Run()
  {
    Console.Write("this is the reflection activity ");
    base.Spin(2000);
    Console.Write("that's all for reflection\n");
    base.PostRun();
  }
}