using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class CycleColorUpLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public CycleColorUpLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.CycleColorUp();
    }

    protected override bool UndoInternal()
    {
      return _lamp.CycleColorDown();
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Cycle Color Up): Lamp {_lamp.Name} switched to the next color \"{_lamp.GetColor()}\" !";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Cycle Color Up): Lamp {_lamp.Name} color cannot change !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Cycle Color Up): Lamp {_lamp.Name} switched to the previous color \"{_lamp.GetColor()}\" !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Cycle Color Up): Lamp {_lamp.Name} color cannot change !";
    }

    public override string ToStringDescription()
    {
      return $"Cycle Lamp {_lamp.Name} to the next color";
    }
  }
}
