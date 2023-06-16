namespace CommandPatternExample1.Exception
{
  internal class CannotUndoException : AbstractException
  {
    public CannotUndoException()
        : base("ERROR: Cannot undo...")
    {
    }
  }
}
