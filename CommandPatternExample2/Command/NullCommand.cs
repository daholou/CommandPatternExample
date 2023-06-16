
namespace CommandPatternExample2.Command
{
  internal class NullCommand : ICommand
  {
    public void Execute() {}

    public void Undo() {}

    public string ToStringExecute() { return ""; }

    public string ToStringUndo() { return ""; }

    public string ToStringDescription() { return ""; }
  }
}
