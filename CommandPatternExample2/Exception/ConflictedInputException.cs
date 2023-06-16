using CommandPatternExample2.Util;

namespace CommandPatternExample2.Exception
{
  internal class ConflictedInputException : AbstractException
  {
    public ConflictedInputException(ConsoleKeyInfo consoleKeyInfo)
        : base($"ERROR : Input {ConsoleUtils.ToStringConsoleKeyInfo(consoleKeyInfo)} is mapped multiple times ...")
    {
    }
  }
}

