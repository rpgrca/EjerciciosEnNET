namespace Solution
{
  using NUnit.Framework;
  using Grader.Logic;

  [TestFixture]
  public class Tests
  {
    [Test]
    [TestCase(0.7, ExpectedResult='C')]
    [TestCase(0.9, ExpectedResult='A')]
    [TestCase(0.6, ExpectedResult='D')]
    public static char FixedTest(double score)
    {
      return Kata.Grader(score);
    }
  }
}