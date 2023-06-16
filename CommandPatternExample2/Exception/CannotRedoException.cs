namespace CommandPatternExample2.Exception
{
  internal class CannotRedoException : AbstractException
  {
    public CannotRedoException()
        : base("ERROR: Cannot redo...")
    {
    }
  }
}
