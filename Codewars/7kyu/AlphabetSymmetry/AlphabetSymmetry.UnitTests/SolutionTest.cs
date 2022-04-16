namespace Solution;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using AlphabetSymmetry.Logic;

public static class Solution
{
    public static List<int> Solve(List<string> arr) =>
        arr.Select(v => v.Where((c, i) => Char.ToLower(c) - 97 == i).Count()).ToList();
}

[TestFixture]
public class SolutionTest
{
    [Test]
    public void BasicTest()
    {
        Assert.That(Kata.Solve(new List<string> {"abode", "ABc", "xyzD"}), Is.EqualTo(new List<int> {4, 3, 1}));
        Assert.That(Kata.Solve(new List<string> {"abide", "ABc", "xyz"}), Is.EqualTo(new List<int> {4, 3, 0}));
        Assert.That(Kata.Solve(new List<string> {"IAMDEFANDJKL", "thedefgh", "xyzDEFghijabc"}), Is.EqualTo(new List<int> {6, 5, 7}));
        Assert.That(Kata.Solve(new List<string> {"encode", "abc", "xyzD", "ABmD"}), Is.EqualTo(new List<int> {1, 3, 1, 3}));
    }

    private static Random rnd = new Random();
    public static string randStr(int min, int max) =>
        String.Concat(new char[rnd.Next(min, max)].Select(_ => (char)rnd.Next(97, 123)).Select(c => rnd.Next(0, 2) == 0 ? Char.ToLower(c) : Char.ToUpper(c)).OrderBy(Char.ToLower));

    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; ++i)
        {
            List<string> arr = new string[rnd.Next(3, 20)].Select(_ => randStr(3, 20)).ToList();
            Assert.That(Kata.Solve(arr), Is.EqualTo(Solution.Solve(arr)));
        }
    }
}