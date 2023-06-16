using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class MoveHandArmCommand : ICommand
  {
    private readonly RotatingArm _rotatingArm;
    public MoveHandArmCommand(RotatingArm rotatingArm)
    {
      _rotatingArm = rotatingArm;
    }

    public void Execute()
    {
      _rotatingArm.MoveHand(1);
    }

    public void Undo()
    {
      _rotatingArm.MoveHand(-1);
    }

    public string ToStringExecute()
    {
      return $"Execute Move Hand: Arm {_rotatingArm.Name} hand extended !";
    }

    public string ToStringUndo()
    {
      return $"Undo Move Hand: Arm {_rotatingArm.Name} hand retracted !";
    }

    public string ToStringDescription()
    {
      return $"Extend the hand on Arm {_rotatingArm.Name}";
    }
  }
}
