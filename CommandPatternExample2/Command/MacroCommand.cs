namespace CommandPatternExample2.Command
{
  internal class MacroCommand : ICommand
  {
    private List<ICommand> _commandList;

    public MacroCommand(List<ICommand> commandList)
    {
      _commandList = commandList;
    }

    public void Execute()
    {
      for (int i = 0; i < _commandList.Count; i++)
      {
        _commandList.ElementAt(i).Execute();
      }
    }

    public void Undo()
    {
      for (int i = _commandList.Count - 1; i >= 0; i--)
      {
        _commandList.ElementAt(i).Undo();
      }
    }

    public string ToStringDescription()
    {
      string result = "";
      for (int i = 0; i < _commandList.Count; i++)
      {
        result += _commandList.ElementAt(i).ToStringDescription();
        if (i < _commandList.Count - 1) result += ", ";
      }
      return result;
    }

    public string ToStringExecute()
    {
      string result = "";
      for (int i = 0; i < _commandList.Count; i++)
      {
        result += _commandList.ElementAt(i).ToStringExecute();
        if (i < _commandList.Count - 1) result += ", ";
      }
      return result;
    }

    public string ToStringUndo()
    {
      string result = "";
      for (int i = _commandList.Count - 1; i >= 0; i--)
      {
        result += _commandList.ElementAt(i).ToStringUndo();
        if (i < _commandList.Count - 1) result += ", ";
      }
      return result;
    }
  }
}
