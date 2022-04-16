using NUnit.Framework;
using FindTheVowels.Logic;

namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual(new int[] {}, Kata.VowelIndices("mmm"));
      Assert.AreEqual(new int[] {1, 5}, Kata.VowelIndices("apple"));
      Assert.AreEqual(new int[] {2, 4}, Kata.VowelIndices("super"));
      Assert.AreEqual(new int[] {1, 3, 6}, Kata.VowelIndices("orange"));
      Assert.AreEqual(new int[] {2, 4, 7, 9, 12, 14, 16, 19, 21, 24, 25, 27, 29, 31, 32, 33}, Kata.VowelIndices("supercalifragilisticexpialidocious"));
    }
  }
}