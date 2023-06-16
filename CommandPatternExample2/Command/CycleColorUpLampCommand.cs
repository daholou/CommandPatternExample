using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class CycleColorUpLampCommand : ICommand
  {
    private readonly Lamp _lamp;

    public CycleColorUpLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    public void Execute()
    {
      _lamp.CycleColorUp();
    }

    public void Undo()
    {
      _lamp.CycleColorDown();
    }

    public string ToStringExecute()
    {
      return $"Execute Cycle Color Up: Lamp {_lamp.Name} switched to the next color \"{_lamp.GetColor()}\" !";
    }

    public string ToStringUndo()
    {
      return $"Undo Cycle Color Up: Lamp {_lamp.Name} switched to the previous color \"{_lamp.GetColor()}\" !";
    }

    public string ToStringDescription()
    {
      return $"Cycle Lamp {_lamp.Name} to the next color";
    }
  }
}
