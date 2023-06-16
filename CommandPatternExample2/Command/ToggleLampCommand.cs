using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class ToggleLampCommand : ICommand
  {
    private readonly Lamp _lamp;

    public ToggleLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    public void Execute()
    {
      _lamp.Toggle();
    }

    public void Undo()
    {
      _lamp.Toggle();
    }

    public string ToStringExecute()
    {
      return $"Execute Toggle: Lamp {_lamp.Name} was toggled {_lamp.Status} !";
    }

    public string ToStringUndo()
    {
      return $"Undo Toggle: Lamp {_lamp.Name} was toggled {_lamp.Status} !";
    }

    public string ToStringDescription()
    {
      return $"Toggle on/off Lamp {_lamp.Name}";
    }
  }
}
