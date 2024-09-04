using HighestAndLowest.Logic;

namespace HighestAndLowest.UnitTests;

[TestFixture]
public class RandomTests
{
  [Test]
  public void RandomTest()
  {
    Random r = new Random();
    for(int w = 0; w < 100; w++)
    {
      List<int> numbers = new List<int>();
      for(int i = r.Next(1, 42); i > 0; i--)
        numbers.Add(r.Next(Int32.MinValue, Int32.MaxValue));
      //Console.WriteLine(String.Join(" ", numbers.Select(n => n.ToString()).ToArray()));
      Assert.AreEqual(numbers.Max().ToString() + " " + numbers.Min().ToString(), Kata.HighAndLow(String.Join(" ", numbers.Select(n => n.ToString()).ToArray())));
    }
  }
}