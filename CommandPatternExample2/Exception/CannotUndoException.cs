namespace CommandPatternExample2.Exception
{
  internal class CannotUndoException : AbstractException
  {
    public CannotUndoException()
        : base("ERROR: Cannot undo...")
    {
    }
  }
}
