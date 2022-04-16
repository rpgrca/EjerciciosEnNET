namespace Solution;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using AlphabetSymmetry.Logic;

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
}