using CommandPatternExample1.Util;

namespace CommandPatternExample1.Exception
{
  internal class ConflictedInputException : AbstractException
  {
    public ConflictedInputException(ConsoleKeyInfo consoleKeyInfo)
        : base($"ERROR : Input {ConsoleUtils.ToStringConsoleKeyInfo(consoleKeyInfo)} is mapped multiple times ...")
    {
    }
  }
}

