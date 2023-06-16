using CommandPatternExample1.Command;
using CommandPatternExample1.Exception;
using CommandPatternExample1.History;
using CommandPatternExample1.Util;

namespace CommandPatternExample1.Invoker
{
  internal class KeyboardInvoker1A
  {
    private readonly Dictionary<ConsoleKeyInfo, AbstractCommand> _commandDictionary;
    private readonly ConsoleKeyInfo _undoKey;
    private readonly ConsoleKeyInfo _redoKey;
    private readonly CommandHistory _history = new();

    public KeyboardInvoker1A(
      Dictionary<ConsoleKeyInfo, AbstractCommand> commandDictionary,
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
      else if (_commandDictionary.TryGetValue(consoleKeyInfo, out AbstractCommand? command))
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
