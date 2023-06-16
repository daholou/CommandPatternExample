namespace CommandPatternExample2.Command
{
  internal interface ICommand
  {
    public void Execute();

    public void Undo();

    public string ToStringExecute();

    public string ToStringUndo();

    public string ToStringDescription();
  }
}
