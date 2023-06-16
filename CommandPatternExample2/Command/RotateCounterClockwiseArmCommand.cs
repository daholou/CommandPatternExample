using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class RotateCounterClockwiseArmCommand : ICommand
  {
    private readonly RotatingArm _rotatingArm;
    public RotateCounterClockwiseArmCommand(RotatingArm rotatingArm)
    {
      _rotatingArm = rotatingArm;
    }

    public void Execute()
    {
      _rotatingArm.Rotate(-45);
    }

    public void Undo()
    {
      _rotatingArm.Rotate(45);
    }

    public string ToStringExecute()
    {
      return $"Execute Rotate Counter-Clockwise: Arm {_rotatingArm.Name} rotated 45° counter-clockwise !";
    }

    public string ToStringUndo()
    {
      return $"Undo Rotate Counter-Clockwise: Arm {_rotatingArm.Name} rotated 45° clockwise !";
    }

    public string ToStringDescription()
    {
      return $"Rotate Arm {_rotatingArm.Name} counter-clockwise by 45°";
    }
  }
}
