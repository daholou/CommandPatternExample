using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class DimDownLampCommand : ICommand
  {
    private readonly Lamp _lamp;

    public DimDownLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    public void Execute()
    {
      _lamp.DimDown();
    }

    public void Undo()
    {
      _lamp.DimUp();
    }

    public string ToStringExecute()
    {
      return $"Execute Dim Down: Lamp {_lamp.Name} intensity decreased to {_lamp.Intensity} !";
    }

    public string ToStringUndo()
    {
      return $"Undo Dim Down: Lamp {_lamp.Name} intensity increased to {_lamp.Intensity} !";
    }

    public string ToStringDescription()
    {
      return $"Decrease the intensity of Lamp {_lamp.Name}";
    }
  }
}
