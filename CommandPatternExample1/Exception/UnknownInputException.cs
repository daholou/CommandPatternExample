namespace CommandPatternExample1.Exception
{
  internal class UnknownInputException : AbstractException
  {
    private static string ToStringConsoleKeyInfo(ConsoleKeyInfo consoleKeyInfo)
    {
      string alt = (consoleKeyInfo.Modifiers & ConsoleModifiers.Alt) != 0
          ? "ALT+" : "";
      string shift = (consoleKeyInfo.Modifiers & ConsoleModifiers.Shift) != 0
          ? "SHIFT+" : "";
      string control = (consoleKeyInfo.Modifiers & ConsoleModifiers.Control) != 0
          ? "CTRL+" : "";
      return $"ERROR: Unknown input {alt}{shift}{control}{consoleKeyInfo.Key} ...";
    }

    public UnknownInputException(ConsoleKeyInfo consoleKeyInfo)
        : base(ToStringConsoleKeyInfo(consoleKeyInfo))
    {
    }
  }
}
