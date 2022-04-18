using NUnit.Framework;
using System;
using SimpleStringCharacters.Logic;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void ExampleTests()
    {
        Assert.AreEqual(new int[] {1,18,3,2}, Solution.Solve("Codewars@codewars123.com"));
        Assert.AreEqual(new int[] {7,6,3,2},  Solution.Solve("bgA5<1d-tOwUZTS8yQ"));
        Assert.AreEqual(new int[] {9,9,6,9}, Solution.Solve("P*K4%>mQUDaG$h=cx2?.Czt7!Zn16p@5H"));
        Assert.AreEqual(new int[] {15,8,6,9},  Solution.Solve("RYT'>s&gO-.CM9AKeH?,5317tWGpS<*x2ukXZD"));
    }
}