namespace CommandPatternExample1.Command
{
  internal abstract class AbstractCommand : ICloneable
  {
    private bool _hasExecuted = false;
    private string _message = "";
    protected abstract bool ExecuteInternal();
    protected abstract bool UndoInternal();
    public abstract string ToStringSuccessExecute();
    public abstract string ToStringFailureExecute();
    public abstract string ToStringSuccessUndo();
    public abstract string ToStringFailureUndo();
    public abstract string ToStringDescription();

    public string Message { get { return _message; } }
    public bool HasExecuted { get { return _hasExecuted; } }

    public void Execute()
    {
      if (!_hasExecuted)
      {
        _hasExecuted = ExecuteInternal();
        if (_hasExecuted)
        {
          _message = ToStringSuccessExecute();
        }
        else
        {
          _message = ToStringFailureExecute();
        }
      }
    }

    public void Undo()
    {
      if (_hasExecuted)
      {
        _hasExecuted = !UndoInternal();
        if (!_hasExecuted)
        {
          _message = ToStringSuccessUndo();
        }
        else
        {
          _message = ToStringFailureUndo();
        }
      }
    }

    public object Clone()
    {
      return (AbstractCommand)MemberwiseClone();
    }
  }
}
