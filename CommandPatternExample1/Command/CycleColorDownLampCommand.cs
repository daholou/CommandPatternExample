using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class CycleColorDownLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public CycleColorDownLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.CycleColorDown();
    }

    protected override bool UndoInternal()
    {
      return _lamp.CycleColorUp();
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Cycle Color Down): Lamp {_lamp.Name} switched to the previous color \"{_lamp.GetColor()}\" !";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Cycle Color Down): Lamp {_lamp.Name} color cannot change !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Cycle Color Down): Lamp {_lamp.Name} switched to the next color \"{_lamp.GetColor()}\" !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Cycle Color Down): Lamp {_lamp.Name} color cannot change !";
    }

    public override string ToStringDescription()
    {
      return $"Cycle Lamp {_lamp.Name} to the previous color";
    }
  }
}
