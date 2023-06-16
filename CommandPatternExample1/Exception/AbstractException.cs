namespace CommandPatternExample1.Exception
{
  internal abstract class AbstractException : System.Exception
  {
    public AbstractException(string message)
        : base(message)
    {
    }
  }
}
