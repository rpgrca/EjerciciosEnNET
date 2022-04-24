namespace AreTheNumbersInOrder.UnitTests;

using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using AreTheNumbersInOrder.Logic;

[TestFixture]
public class Tests
{
    [Test]
    [TestCase(new int[]{1,2}, ExpectedResult=true)]
    [TestCase(new int[]{2,1}, ExpectedResult=false)]
    [TestCase(new int[]{1,2,3}, ExpectedResult=true)]
    [TestCase(new int[]{1,3,2}, ExpectedResult=false)]
    [TestCase(new int[]{2,1,3}, ExpectedResult=false)]
    [TestCase(new int[]{2,3,1}, ExpectedResult=false)]
    [TestCase(new int[]{3,1,2}, ExpectedResult=false)]
    [TestCase(new int[]{3,2,1}, ExpectedResult=false)]
    public static bool BasicFixedTest(int[] arr)
    {
        return Kata.IsAscOrder(arr);
    }

    [Test]
    [TestCase(new int[]{1,4,13,97,508,1047,20058}, ExpectedResult=true)]
    [TestCase(new int[]{56,98,123,67,742,1024,32,90969}, ExpectedResult=false)]
    public static bool AdvancedFixedTest(int[] arr)
    {
        return Kata.IsAscOrder(arr);
    }

    [Test]
    public static void RandomTest([Random(0,1,10)]int sorted, [Random(1,20,10)]int arrLen)
    {
        int[] arr = GetRandomArray(arrLen);
        if(sorted == 1)
        {
            arr = arr.OrderBy(x => x).ToArray();
        }
        Assert.AreEqual(Solution(arr), Kata.IsAscOrder(arr), string.Format("Should work for {0}", string.Join(", ", arr)));
    }

    private static bool Solution(int[] arr)
    {
        return string.Join("", arr) == string.Join("", arr.OrderBy(x => x));
    }

    private static int[] GetRandomArray(int len)
    {
        List<int> list = new List<int>();
        Random r = new Random();
        for(int i = 0; i < len; i++)
        {
            list.Add(r.Next(100));
        }

        return list.ToArray();
    }
}