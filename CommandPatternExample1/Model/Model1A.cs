using CommandPatternExample1.Invoker;
using CommandPatternExample1.Receiver;
using CommandPatternExample1.Util;

namespace CommandPatternExample1.Model
{
  internal class Model1A : AbstractModel
  {
    private readonly Lamp[] _lamps;
    private readonly KeyboardInvoker1A _keyboardInvoker;

    public Model1A(Lamp[] lamps, KeyboardInvoker1A keyboardInvoker)
    {
      _lamps = lamps;
      _keyboardInvoker = keyboardInvoker;
    }

    protected override string ApplyConsoleKeyInfo(ConsoleKeyInfo keyInfo)
    {
      return _keyboardInvoker.OnPress(keyInfo);
    }

    public override void Display()
    {
      ConsoleUtils.DrawLine();
      Console.WriteLine("|   LAMP DETAILS");
      ConsoleUtils.DrawLine();
      foreach (Lamp lamp in _lamps)
      {
        Console.WriteLine(lamp.ToString());
      }
      ConsoleUtils.DrawLine();
      Console.WriteLine("|   AVAILABLE COMMANDS");
      ConsoleUtils.DrawLine();
      Console.WriteLine(_keyboardInvoker.ToString());
      ConsoleUtils.DrawLine();
    }
  }
}
