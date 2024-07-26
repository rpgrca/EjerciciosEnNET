using Collinearity.Logic;
using NUnit.Framework;
using System;

namespace Collinearity.UnitTests;


// TODO: Replace examples and use TDD by writing your own tests

[TestFixture]
public class SolutionTest
{
    [TestCase(1, 1, 1, 1, ExpectedResult = true)]
    [TestCase(1, 2, 2, 4, ExpectedResult = true)]
    public bool Vectors_Directed_SameDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

    [TestCase(1, 1, -1, -1, ExpectedResult = true)]
    [TestCase(1, -2, -2, 4, ExpectedResult = true)]
    public bool Vectors_Directed_OppositeDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

    [TestCase(1, 1, 6, 1, ExpectedResult = false)]
    [TestCase(1, 2, 1, -2, ExpectedResult = false)]
    public bool Vectors_Directed_DifferentDirections(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);

    [TestCase(4, 0, 11, 0, ExpectedResult = true)]
    [TestCase(0, 1, 6, 0, ExpectedResult = false)]
    [TestCase(4, 4, 0, 4, ExpectedResult = false)]
    [TestCase(0, 0, 0, 0, ExpectedResult = true)]
    [TestCase(0, 0, 1, 0, ExpectedResult = true)]
    [TestCase(5, 7, 0, 0, ExpectedResult = true)]
    public bool Vectors_Contains_Zeros(int x1, int x2, int y1, int y2) => Kata.Collinearity(x1, x2, y1, y2);
}