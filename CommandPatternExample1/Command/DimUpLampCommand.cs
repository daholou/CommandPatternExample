using CommandPatternExample1.Receiver;

namespace CommandPatternExample1.Command
{
  internal class DimUpLampCommand : AbstractCommand
  {
    private readonly Lamp _lamp;

    public DimUpLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    protected override bool ExecuteInternal()
    {
      return _lamp.DimUp();
    }

    protected override bool UndoInternal()
    {
      return _lamp.DimDown();
    }

    public override string ToString()
    {
      return "Increased lamp intensity";
    }

    public override string ToStringSuccessExecute()
    {
      return $"Success (Execute Dim Up): Lamp {_lamp.Name} intensity increased to {_lamp.Intensity} !";
    }

    public override string ToStringFailureExecute()
    {
      return $"Failure (Execute Dim Up): Lamp {_lamp.Name} intensity cannot increase !";
    }

    public override string ToStringSuccessUndo()
    {
      return $"Success (Undo Dim Up): Lamp {_lamp.Name} intensity decreased to {_lamp.Intensity} !";
    }

    public override string ToStringFailureUndo()
    {
      return $"Failure (Undo Dim Up): Lamp {_lamp.Name} intensity cannot decrease !";
    }

    public override string ToStringDescription()
    {
      return $"Increase the intensity of Lamp {_lamp.Name}";
    }
  }
}
