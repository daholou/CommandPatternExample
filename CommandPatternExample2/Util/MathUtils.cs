using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternExample2.Util
{
  internal class MathUtils
  {
    private MathUtils() { }

    public static int PositiveModulo(int n, int q)
    {
      if (q <= 0) return 0; // unsupported operation
      int modulo = n % q;
      return modulo < 0 ? modulo + q : modulo;
    }
  }
}
