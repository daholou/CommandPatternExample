namespace CommandPatternExample1.Model
{
  internal class KeyReader
  {
    private readonly AbstractModel _model;
    private readonly int _originLeft;
    private readonly int _originTop;

    public KeyReader(AbstractModel model, int originLeft, int originTop)
    {
      _model = model;
      _originLeft = originLeft;
      _originTop = originTop;
    }

    private static ConsoleKeyInfo ReadUserInput()
    {
      Console.Write("Press any key, or Escape (Esc) key to quit: ");
      return Console.ReadKey();
    }

    public void Run()
    {
      ConsoleKeyInfo consoleKeyInfo;
      string message = "";
      // Prevent from ending if CTRL+C is pressed.
      Console.TreatControlCAsInput = true;
      do
      {
        Console.Clear();
        // place the cursor on origin
        Console.SetCursorPosition(_originLeft, _originTop);
        // print the model
        _model.Display();
        // write a message about the last thing that happened
        Console.WriteLine(message);
        // prompt for a new key input
        consoleKeyInfo = ReadUserInput();
        Console.WriteLine();
        message = _model.ReadConsoleKeyInfo(consoleKeyInfo);
      } while (consoleKeyInfo.Key != ConsoleKey.Escape);
    }
  }
}
