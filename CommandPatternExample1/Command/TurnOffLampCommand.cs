using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class TurnOffLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public TurnOffLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.Toggle(false);
    }

    protected override bool UndoInternal()
    {
      return _lamp.Toggle(true);
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Turn Off): Lamp {_lamp.Name} was turned off !";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Turn Off): Lamp {_lamp.Name} cannot turn off !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Turn Off): Lamp {_lamp.Name} was turned on !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Turn Off): Lamp {_lamp.Name} cannot turn on !";
    }

    public override string ToStringDescription()
    {
      return $"Toggle off Lamp {_lamp.Name}";
    }
  }
}
