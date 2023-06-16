using CommandPatternExample2.Invoker;
using CommandPatternExample2.Receiver;
using CommandPatternExample2.Util;

namespace CommandPatternExample2.Model
{
  internal class Model2A : AbstractModel
  {
    private readonly List<Lamp> _lamps;
    private readonly List<RotatingArm> _rotatingArms;
    private readonly KeyboardInvoker2A _keyboardInvoker;

    public Model2A(
      List<Lamp> lamps,
      List<RotatingArm> rotatingArms,
      KeyboardInvoker2A keyboardInvoker)
    {
      _lamps = lamps;
      _rotatingArms = rotatingArms;
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
      Console.WriteLine("|   ROTATING ARMS DETAILS");
      ConsoleUtils.DrawLine();
      foreach (RotatingArm rotatingArm in _rotatingArms)
      {
        Console.WriteLine(rotatingArm.ToString());
      }
      ConsoleUtils.DrawLine();
      Console.WriteLine("|   AVAILABLE COMMANDS");
      ConsoleUtils.DrawLine();
      Console.WriteLine(_keyboardInvoker.ToString());
      ConsoleUtils.DrawLine();
    }
  }
}
