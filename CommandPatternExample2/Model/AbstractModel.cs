using CommandPatternExample2.Exception;

namespace CommandPatternExample2.Model
{
  internal abstract class AbstractModel
  {
    protected abstract string ApplyConsoleKeyInfo(ConsoleKeyInfo keyInfo);

    public string ReadConsoleKeyInfo(ConsoleKeyInfo keyInfo)
    {
      try
      {
        return ApplyConsoleKeyInfo(keyInfo);
      }
      catch (AbstractException e)
      {
        return e.Message;
      }
    }

    public abstract void Display();
  }
}
