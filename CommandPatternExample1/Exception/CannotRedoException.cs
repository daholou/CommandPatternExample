namespace CommandPatternExample1.Exception
{
  internal class CannotRedoException : AbstractException
  {
    public CannotRedoException()
        : base("ERROR: Cannot redo...")
    {
    }
  }
}
