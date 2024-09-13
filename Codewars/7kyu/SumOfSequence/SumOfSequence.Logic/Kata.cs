namespace SumOfSequence.Logic;

public class Kata
{
  public static int SequenceSum(int start, int end, int step)
  {
    if (start > end) return 0;

    var result = 0;
    for (var index = start; index <= end; index += step) {
        result += index;
    }

    return result;
  }
}
