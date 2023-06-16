using CommandPatternExample2.Util;

namespace CommandPatternExample2.Receiver
{
  internal class RotatingArm
  {
    private readonly int _length;
    private int _angle;
    private int _handPosition;
    private readonly string _name;

    public RotatingArm(string name, int length = 5, int angle = 0)
    {
      _name = name;
      _length = Math.Max(1, length);
      _angle = MathUtils.PositiveModulo(angle, 360);
      _handPosition = 0;
    }

    public void Rotate(int angle)
    {
      _angle = MathUtils.PositiveModulo(_angle + angle, 360);
    }

    public void MoveHand(int value)
    {
      _handPosition = MathUtils.PositiveModulo(_handPosition + value, _length);
    }

    public string Name { get { return _name; } }
    public int Length { get { return _length; } }
    public int Angle { get { return _angle; } }
    public int HandPosition { get { return _handPosition; } }

    public string GetLengthSymbol()
    {
      int spaceCountLeft = _handPosition;
      int spaceCountRight = _length - spaceCountLeft - 1;
      string left = spaceCountLeft > 0 ? new string('-', spaceCountLeft) : "";
      string right = spaceCountRight > 0 ? new string('-', spaceCountRight) : "";
      return $">{left}O{right}";
    }

    public string GetAngleSymbolTop()
    {
      return (_angle / 45) switch
      {
        0 => "_  ",  // 0
        1 => "\\  ", // 45
        2 => " | ",  // 90
        3 => "  /",  // 135
        4 => "  _",  // 180
        _ => "   "   // 225+
      };
    }
    public string GetAngleSymbolBottom()
    {
      return (_angle / 45) switch
      {
        5 => "  \\", // 225
        6 => " | ",  // 270
        7 => "/  ",  // 315
        _ => "   "   // 360+
      };
    }


    public override string ToString()
    {
      string row1 = $"| |{GetAngleSymbolTop()}|  Rotating Arm {Name} [Angle : {Angle}] (Length : {Length})\n";
      string row2 = $"| |{GetAngleSymbolBottom()}|  {GetLengthSymbol()}";
      return row1 + row2;
    }
  }
}
