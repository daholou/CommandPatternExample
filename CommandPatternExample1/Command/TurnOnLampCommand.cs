using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class TurnOnLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public TurnOnLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.Toggle(true);
    }

    protected override bool UndoInternal()
    {
      return _lamp.Toggle(false);
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Turn On): Lamp {_lamp.Name} was turned on !";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Turn On): Lamp {_lamp.Name} cannot turn on !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Turn On): Lamp {_lamp.Name} was turned off !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Turn On): Lamp {_lamp.Name} cannot turn off !";
    }

    public override string ToStringDescription()
    {
      return $"Toggle on Lamp {_lamp.Name}";
    }
  }
}
