using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class NullCommand : AbstractCommand
  {
    protected override bool ExecuteInternal()
    {
      return false;
    }

    protected override bool UndoInternal()
    {
      return false;
    }

    public override string ToStringSuccessExecute()
    {
      return "";
    }

    public override string ToStringFailureExecute()
    {
      return "";
    }

    public override string ToStringSuccessUndo()
    {
      return "";
    }

    public override string ToStringFailureUndo()
    {
      return "";
    }

    public override string ToStringDescription()
    {
      return "";
    }
  }
}
