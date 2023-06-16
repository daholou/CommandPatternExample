using CommandPatternExample2.Command;
using CommandPatternExample2.Invoker;
using CommandPatternExample2.Model;
using CommandPatternExample2.Receiver;
using CommandPatternExample2.Util;

namespace CommandPatternExample2
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("COMMAND PATTERN EXAMPLE 2 - APP");

      // define the model
      Lamp lampA = new("A", 1, 10);
      Lamp lampB = new("B", 5, 20);
      List<Lamp> lamps = new(){ lampA, lampB };
      RotatingArm armC = new("C", 29, 90);
      RotatingArm armD = new("D", 17);
      List<RotatingArm> arms = new() { armC, armD };
      MacroCommand macroCommand1 = new(new List<ICommand>()
        {
          new ToggleLampCommand(lampA),
          new ToggleLampCommand(lampB)
        }
      );
      MacroCommand macroCommand2 = new(new List<ICommand>()
        {
          new DimUpLampCommand(lampA),
          new DimDownLampCommand(lampB)
        }
      );
      MacroCommand macroCommand3 = new(new List<ICommand>()
        {
          new RotateClockwiseArmCommand(armC),
          new RotateCounterClockwiseArmCommand(armD)
        }
      );
      MacroCommand macroCommand4 = new(new List<ICommand>()
        {
          new MoveHandArmCommand(armC),
          new MoveHandArmCommand(armD)
        }
      );
      MacroCommand macroCommand5 = new(new List<ICommand>()
        {
          macroCommand3,
          macroCommand4
        }
      );
      Dictionary<ConsoleKeyInfo, ICommand> commandDictionary = new(new ConsoleKeyInfoComparer())
      {
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.A), new ToggleLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Z), new ToggleLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.E), macroCommand1 },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.R), macroCommand2 },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.T), new DimUpLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Y), new DimDownLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Add), new DimUpLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Subtract), new DimDownLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.UpArrow), new CycleColorUpLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.DownArrow), new CycleColorDownLampCommand(lampA) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.RightArrow), new CycleColorUpLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.LeftArrow), new CycleColorDownLampCommand(lampB) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Q), new RotateClockwiseArmCommand(armC) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.S), new RotateCounterClockwiseArmCommand(armC) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.D), new MoveHandArmCommand(armC) },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.NumPad4), macroCommand3 },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.NumPad5), macroCommand4 },
        { ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.NumPad6), macroCommand5 },
      };
      KeyboardInvoker2A keyboardInvoker = new(
          commandDictionary,
          ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Z, false, false, true),
          ConsoleUtils.MakeConsoleKeyInfo(ConsoleKey.Y, false, false, true)
      );
      Model2A model = new(lamps, arms, keyboardInvoker);

      // define the input reader with top & left cursor coords
      int originLeft = Console.CursorLeft;
      int originTop = Console.CursorTop;
      KeyReader keyReader = new(model, originLeft, originTop);

      // start the application
      keyReader.Run();
    }
  }
}
