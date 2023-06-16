using CommandPatternExample1.Command;
using CommandPatternExample1.Exception;

namespace CommandPatternExample1.History
{
  internal class CommandHistory
  {
    private readonly Stack<AbstractCommand> _undoStack = new();
    private readonly Stack<AbstractCommand> _redoStack = new();

    public string ExecuteCommand(AbstractCommand command)
    {
      AbstractCommand copiedCommand = (AbstractCommand)command.Clone();

      copiedCommand.Execute();
      if (copiedCommand.HasExecuted)
      {
        _undoStack.Push(copiedCommand);
        _redoStack.Clear();
      }
      return copiedCommand.Message;
    }

    public string Undo()
    {
      if (_undoStack.Count > 0)
      {
        AbstractCommand command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
        return command.Message;
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
        AbstractCommand command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
        return command.Message;
      }
      else
      {
        throw new CannotRedoException();
      }
    }
  }
}
