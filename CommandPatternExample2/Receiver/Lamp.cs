namespace CommandPatternExample2.Receiver
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

    public void Toggle()
    {
      _isOn = !_isOn;
    }

    public void DimDown()
    {
      if (_intensity > _minIntensity)
      {
        _intensity--;
      }
      else
      {
        _intensity = _maxIntensity;
      }
    }

    public void DimUp()
    {
      if (_intensity < _maxIntensity)
      {
        _intensity++;
      }
      else
      {
        _intensity = _minIntensity;
      }
    }

    public void CycleColorUp()
    {
      _colorIndex = (_colorIndex + 1) % 4;
    }

    public void CycleColorDown()
    {
      _colorIndex = (_colorIndex + 3) % 4;
    }

    public override string ToString()
    {
      string data = $"Lamp {Name} [Status : {Status}] (Color : {GetColor()}) Intensity (min/cur/max) : {_minIntensity} / {_intensity} / {_maxIntensity}";
      return $"| {data}";
    }
  }
}
