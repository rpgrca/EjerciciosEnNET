using System.Linq;

namespace ToSquareRootOrNotToSquareRoot.Logic;

public class Kata
{
    public static int[] SquareOrSquareRoot(int[] array)
    {
        return array.Select(p => {
          var root = (int)Math.Sqrt(p);
          var power = (int)Math.Pow(root, 2);
          return p == power ? root : (int)Math.Pow(p, 2);
        }).ToArray();
    }
}