using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class DimDownLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public DimDownLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.DimDown();
    }

    protected override bool UndoInternal()
    {
      return _lamp.DimUp();
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Dim Down): Lamp {_lamp.Name} intensity decreased to {_lamp.Intensity}!";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Dim Down): Lamp {_lamp.Name} intensity cannot decrease !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Dim Down): Lamp {_lamp.Name} intensity increased to {_lamp.Intensity} !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Dim Down): Lamp {_lamp.Name} intensity cannot increase !";
    }

    public override string ToStringDescription()
    {
      return $"Decrease the intensity of Lamp {_lamp.Name}";
    }
  }
}
