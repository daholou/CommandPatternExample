using CommandPatternExample2.Command;
using CommandPatternExample2.Exception;

namespace CommandPatternExample2.History
{
  internal class CommandHistory
  {
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();

    public string ExecuteCommand(ICommand command)
    {
      command.Execute();
      _undoStack.Push(command);
      _redoStack.Clear();
      return command.ToStringExecute();
    }

    public string Undo()
    {
      if (_undoStack.Count > 0)
      {
        ICommand command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        return command.ToStringUndo();
      }
      else
      {
        throw new CannotUndoException();
      }
    }

    public string Redo()
    {
      if (_redoStack.Count > 0)
      {
        ICommand command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
        return command.ToStringExecute();
      }
      else
      {
        throw new CannotRedoException();
      }
    }
  }
}
