using CommandPatternExample2.Receiver;

namespace CommandPatternExample2.Command
{
  internal class CycleColorDownLampCommand : ICommand
  {
    private readonly Lamp _lamp;

    public CycleColorDownLampCommand(Lamp lamp)
    {
      _lamp = lamp;
    }

    public void Execute()
    {
      _lamp.CycleColorDown();
    }

    public void Undo()
    {
      _lamp.CycleColorUp();
    }

    public string ToStringExecute()
    {
      return $"Execute Cycle Color Down: Lamp {_lamp.Name} switched to the previous color \"{_lamp.GetColor()}\" !";
    }

    public string ToStringUndo()
    {
      return $"Undo Cycle Color Down: Lamp {_lamp.Name} switched to the next color \"{_lamp.GetColor()}\" !";
    }

    public string ToStringDescription()
    {
      return $"Cycle Lamp {_lamp.Name} to the previous color";
    }
  }
}
