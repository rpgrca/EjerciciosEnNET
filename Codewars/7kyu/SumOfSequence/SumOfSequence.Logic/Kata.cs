namespace SumOfSequence.Logic;

public class Kata
{
  public static int SequenceSum(int start, int end, int step)
  {
    var result = 0;
    for (var current = start; current <= end; current += step) {
        result += current;
    }

    return result;
  }
}
