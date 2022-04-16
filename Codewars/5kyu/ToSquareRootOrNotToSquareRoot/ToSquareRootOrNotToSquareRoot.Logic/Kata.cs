using System.Linq;

namespace ToSquareRootOrNotToSquareRoot.Logic;

public class Kata
{
    public static int[] SquareOrSquareRoot(int[] array)
    {
        return array.Select(p => {
          var root = Math.Sqrt(p);
          return root == (int)root ? (int)root : (int)Math.Pow(p, 2);
        }).ToArray();
    }
}