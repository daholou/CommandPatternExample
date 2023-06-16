namespace CommandPatternExample1.Util
{
  internal class ConsoleUtils
  {
    private ConsoleUtils() { }

    public static void DrawLine()
    {
      Console.Write('+');
      Console.Write(new string('-', Console.WindowWidth - 3));
      Console.WriteLine('+');
    }

    public static string ToStringConsoleKeyInfo(ConsoleKeyInfo consoleKeyInfo)
    {
      string alt = (consoleKeyInfo.Modifiers & ConsoleModifiers.Alt) != 0
          ? "ALT+" : "";
      string shift = (consoleKeyInfo.Modifiers & ConsoleModifiers.Shift) != 0
          ? "SHIFT+" : "";
      string control = (consoleKeyInfo.Modifiers & ConsoleModifiers.Control) != 0
          ? "CTRL+" : "";
      return $"{alt}{shift}{control}{consoleKeyInfo.Key}";
    }

    public static ConsoleKeyInfo MakeConsoleKeyInfo(
      ConsoleKey consoleKey,
      bool altModifier = false,
      bool shiftModifier = false,
      bool controlModifier = false
    )
    {
      return new ConsoleKeyInfo((char)consoleKey, consoleKey, altModifier, shiftModifier, controlModifier);
    }
  }
}
