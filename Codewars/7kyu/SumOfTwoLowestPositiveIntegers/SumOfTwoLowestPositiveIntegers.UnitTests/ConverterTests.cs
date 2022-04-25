using NUnit.Framework;
using System;
using System.Collections.Generic;
using SumOfTwoLowestPositiveIntegers.Logic;

[TestFixture]
public class ConverterTests
{
    [Test]
    public void Test1()
    {
        int[] numbers = {5, 8, 12, 19, 22};
        Assert.AreEqual(13, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void Test2()
    {
        int[] numbers = {15, 28, 4, 2, 43};
        Assert.AreEqual(6, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void Test3()
    {
        int[] numbers = {3, 87, 45, 12, 7};
        Assert.AreEqual(10, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void Test4()
    {
        int[] numbers = {23, 71, 33, 82, 1};
        Assert.AreEqual(24, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void Test5()
    {
        int[] numbers = {52, 76, 14, 12, 4};
        Assert.AreEqual(16, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void Test6()
    {
        int[] numbers = {1000, 2, 3, 6};
        Assert.AreEqual(5, Kata.sumTwoSmallestNumbers(numbers));
    }

    [Test]
    public void TestRandomNumbers()
    {
        Random rnd = new Random();
        for (int run = 0; run < 100; ++run)
        {
            var numbers = new int[rnd.Next(4, 100)];
            int min1 = Int32.MaxValue;
            int min2 = Int32.MaxValue;
            for(int i = 0; i < numbers.Length; ++i)
            {
                int n = rnd.Next(1, 1000000);
                if(n < min1) { min2 = min1; min1 = n; }
                else if(n < min2) min2 = n;
                numbers[i] = n;
            }
            int expected = min1 + min2;
            int actual = Kata.sumTwoSmallestNumbers(numbers);
            Assert.AreEqual(expected, actual, "Lowest numbers are " + min1 + " and " + min2);
        }
    }
}