using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class DimUpLampCommand : ICommand
  {
    private readonly Lamp _lamp;

    public DimUpLampCommand(Lamp lamp) 
    {
      _lamp = lamp;
    }

    public void Execute()
    {
      _lamp.DimUp();
    }

    public void Undo()
    {
      _lamp.DimDown();
    }

    public string ToStringExecute()
    {
      return $"Execute Dim Up: Lamp {_lamp.Name} intensity increased to {_lamp.Intensity} !";
    }

    public string ToStringUndo()
    {
      return $"Undo Dim Up: Lamp {_lamp.Name} intensity decreased to {_lamp.Intensity} !";
    }

    public string ToStringDescription()
    {
      return $"Increase the intensity of Lamp {_lamp.Name}";
    }
  }
}
