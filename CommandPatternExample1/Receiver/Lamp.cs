namespace CommandPatternExample1.Receiver
{
  internal class Lamp
  {
    private readonly string _name;
    private int _intensity;
    private readonly int _minIntensity;
    private readonly int _maxIntensity;
    private int _colorIndex;
    private bool _isOn = false;

    public string GetColor()
    {
      return _colorIndex switch
      {
        0 => "Red",
        1 => "Green",
        2 => "Blue",
        3 => "White",
        _ => "Unknown color"
      };
    }

    public int Intensity { get { return _intensity; } }
    public string Name { get { return _name; } }
    public string Status { get { return _isOn ? "ON" : "OFF"; } }

    public Lamp(string name, int minIntensity, int maxIntensity)
    {
      _name = name;
      _intensity = minIntensity;
      _minIntensity = minIntensity;
      // ensures _maxIntensity >= _minIntensity
      _maxIntensity = Math.Max(minIntensity, maxIntensity);
      _isOn = false;
      _colorIndex = 0;
    }

    public bool Toggle(bool isOn)
    {
      if (_isOn == isOn)
      {
        return false;
      }
      else
      {
        _isOn = isOn;
        return true;
      }
    }

    public bool DimDown()
    {
      if (!_isOn) return false;
      int intensity = Math.Max(_intensity - 1, _minIntensity);
      if (_intensity == intensity)
      {
        return false;
      }
      else
      {
        _intensity = intensity;
        return true;
      }
    }

    public bool DimUp()
    {
      if (!_isOn) return false;
      int intensity = Math.Min(_intensity + 1, _maxIntensity);
      if (_intensity == intensity)
      {
        return false;
      }
      else
      {
        _intensity = intensity;
        return true;
      }
    }

    public bool CycleColorUp()
    {
      if (!_isOn) return false;
      _colorIndex = (_colorIndex + 1) % 4;
      return true;
    }

    public bool CycleColorDown()
    {
      if (!_isOn) return false;
      _colorIndex = (_colorIndex + 3) % 4;
      return true;
    }

    public override string ToString()
    {
      string data = $"Lamp {Name} [Status : {Status}] (Color : {GetColor()}) Intensity (min/cur/max) : {_minIntensity} / {_intensity} / {_maxIntensity}";
      return $"| {data}";
    }
  }
}
