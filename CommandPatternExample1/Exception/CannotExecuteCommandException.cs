namespace CommandPatternExample1.Exception
{
  internal class CannotExecuteCommandException : AbstractException
  {
    public CannotExecuteCommandException()
        : base("ERROR: Cannot execute command...")
    {
    }
  }
}
