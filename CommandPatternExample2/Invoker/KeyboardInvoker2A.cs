using CommandPatternExample2.Command;
using CommandPatternExample2.Exception;
using CommandPatternExample2.History;
using CommandPatternExample2.Util;

namespace CommandPatternExample2.Invoker
{
  internal class KeyboardInvoker2A
  {
    private readonly Dictionary<ConsoleKeyInfo, ICommand> _commandDictionary;
    private readonly ConsoleKeyInfo _undoKey;
    private readonly ConsoleKeyInfo _redoKey;
    private readonly CommandHistory _history = new();

    public KeyboardInvoker2A(
      Dictionary<ConsoleKeyInfo, ICommand> commandDictionary,
      ConsoleKeyInfo undoKey,
      ConsoleKeyInfo redoKey
    )
    {
      if (commandDictionary.Comparer.Equals(undoKey, redoKey) || commandDictionary.ContainsKey(undoKey))
      {
        throw new ConflictedInputException(undoKey);
      }
      if (commandDictionary.ContainsKey(redoKey))
      {
        throw new ConflictedInputException(redoKey);
      }
      _commandDictionary = commandDictionary;
      _undoKey = undoKey;
      _redoKey = redoKey;
    }

    public override string ToString()
    {
      string result = "";
      foreach (var item in _commandDictionary)
      {
        string keyBinding = ConsoleUtils.ToStringConsoleKeyInfo(item.Key);
        string description = item.Value.ToStringDescription();
        result += $"| {keyBinding} - {description}\n";
      }
      result += $"| {ConsoleUtils.ToStringConsoleKeyInfo(_undoKey)} - Undo command\n";
      result += $"| {ConsoleUtils.ToStringConsoleKeyInfo(_redoKey)} - Redo command";
      return result;
    }

    public string OnPress(ConsoleKeyInfo consoleKeyInfo)
    {
      if (_commandDictionary.Comparer.Equals(_redoKey, consoleKeyInfo))
      {
        return _history.Redo();
      }
      else if (_commandDictionary.Comparer.Equals(_undoKey, consoleKeyInfo))
      {
        return _history.Undo();
      }
      else if (_commandDictionary.TryGetValue(consoleKeyInfo, out ICommand? command))
      {
        return _history.ExecuteCommand(command);
      }
      else
      {
        throw new UnknownInputException(consoleKeyInfo);
      }
    }
  }
}
