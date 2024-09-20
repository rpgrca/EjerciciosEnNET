using FindTheDivisors.Logic;
using NUnit.Framework;
using System;

namespace FindTheDivisors.UnitTests;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class SolutionTest
{
  [Test]
  public void FixedTests()
  {
    Assert.AreEqual(null, Kata.Divisors(2), "n = 2");
    Assert.AreEqual(null, Kata.Divisors(3), "n = 3");
    Assert.AreEqual(new int[] {2}, Kata.Divisors(4), "n = 4");
    Assert.AreEqual(null, Kata.Divisors(5), "n = 5");
    Assert.AreEqual(new int[] {2, 3}, Kata.Divisors(6), "n = 6");
    Assert.AreEqual(null, Kata.Divisors(7), "n = 7");
    Assert.AreEqual(new int[] {2, 4}, Kata.Divisors(8), "n = 8");
    Assert.AreEqual(new int[] {3}, Kata.Divisors(9), "n = 9");
    Assert.AreEqual(new int[] {2, 5}, Kata.Divisors(10), "n = 10");
    Assert.AreEqual(null, Kata.Divisors(11), "n = 11");
    Assert.AreEqual(new int[] {2, 3, 4, 6}, Kata.Divisors(12), "n = 12");
    Assert.AreEqual(null, Kata.Divisors(13), "n = 13");
    Assert.AreEqual(new int[] {2, 7}, Kata.Divisors(14), "n = 14");
    Assert.AreEqual(new int[] {3, 5}, Kata.Divisors(15));
    Assert.AreEqual(new int[] {2, 4, 8}, Kata.Divisors(16));
    Assert.AreEqual(new int[] {2, 3, 4, 6, 8, 12}, Kata.Divisors(24));
    Assert.AreEqual(new int[] {11, 23}, Kata.Divisors(253));
  }
  
  private static readonly Random rnd = new Random();
  
  private static int[] solution(int n)
  {
    // 1 and 2 are prime
    if (n <= 2) { return null; }
  
    // Only need to check up until the square root of n
    double sqrt = Math.Sqrt(n);
    
    List<int> divisors = new List<int>();
    
    // Get first half of divisors
    for (double i = 2; i < sqrt; ++i)
    {
      // if n / i is integer
      if (n / i % 1 == 0)
      {
        divisors.Add((int)i);
      }
    }
    
    // Concat flipped divisors onto our list
    divisors = divisors.Concat(
    
      // Reverse flipped divisors, (24) {2, 3, 4} => {12, 8, 6} => {6, 8, 12}
      Enumerable.Reverse(divisors.Select(v => n / v))
    ).ToList();
    
    // If n is a perfect square, insert sqrt into the middle of the list
    if (sqrt % 1 == 0)
    {
      divisors.Insert(divisors.Count / 2, (int)sqrt);
    }
    
    // If our list of divisors is still empty, return null as n is prime
    if (divisors.Count == 0) { return null; }
    
    return divisors.ToArray();
  }
  
  [Test, Description("Light Random Tests")]
  public void LightRandomTests()
  {
    for (int i = 0; i < 100; ++i)
    {
      int n = rnd.Next(2, 1000);
      int[] expected = solution(n);
      int[] actual = Kata.Divisors(n);
      Assert.AreEqual(expected, actual, $"n = {n}");
    }
  }
  
  /*[Test, Description("Performance Random Tests")]
  public void HeavyRandomTests()
  {
    for (int i = 0; i < 1000; ++i)
    {
      int test = int.MaxValue - rnd.Next(2, 100001);
      int[] expected = solution(test);
      int[] actual = Kata.Divisors(test);
      Assert.AreEqual(expected, actual);
    }
  }*/
}