namespace HighestAndLowest.Logic;

public class Kata
{
  public static string HighAndLow(string numbers)
  {
    // Code here or
    var values = numbers.Split(" ").Select(int.Parse).OrderBy(p => p).ToList();
    return $"{values[^1]} {values[0]}";
  }
}
