using CommandPatternExample1.Command;
using CommandPatternExample1.Invoker;
using CommandPatternExample1.Model;
using CommandPatternExample1.Receiver;
using CommandPatternExample1.Util;

namespace CommandPatternExample1
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("COMMAND PATTERN EXAMPLE 1 - APP");

      // define the model
      Lamp lampA = new("A", 1, 10);
      Lamp lampB = new("B", 5, 20);
      Lamp[] lamps = { lampA, lampB };
      Dictionary<ConsoleKeyInfo, AbstractCommand> commandDictionary = new(new ConsoleKeyInfoComparer())
      {
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.A), new TurnOnLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Z), new TurnOffLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.E), new TurnOnLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.R), new TurnOffLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.T), new DimUpLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Y), new DimDownLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Add), new DimUpLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Subtract), new DimDownLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.UpArrow), new CycleColorUpLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.DownArrow), new CycleColorDownLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.RightArrow), new CycleColorUpLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.LeftArrow), new CycleColorDownLampCommand(lampB) }
      };
      KeyboardInvoker1A keyboardInvoker = new(
          commandDictionary,
          ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Z, false, false, true),
          ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Y, false, false, true)
      );
      Model1A model = new(lamps, keyboardInvoker);

      // define the input reader with top & left cursor coords
      int originLeft = Console.CursorLeft;
      int originTop = Console.CursorTop;
      KeyReader keyReader = new(model, originLeft, originTop);

      // start the application
      keyReader.Run();
    }
  }
}
