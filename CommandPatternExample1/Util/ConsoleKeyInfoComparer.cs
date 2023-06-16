namespace CommandPatternExample1.Util
{
  internal class ConsoleKeyInfoComparer : IEqualityComparer<ConsoleKeyInfo>
  {
    public bool Equals(ConsoleKeyInfo x, ConsoleKeyInfo y)
    {
      return x.Key == y.Key && x.Modifiers == y.Modifiers;
    }

    public int GetHashCode(ConsoleKeyInfo obj)
    {
      int hashCode = obj.Key.GetHashCode() ^ obj.Modifiers.GetHashCode();
      return hashCode;
    }
  }
}
