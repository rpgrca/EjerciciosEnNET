namespace Solution;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using ListFiltering.Logic;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void GetIntegersFromList_MixedValues_ShouldPass_1()
    {
        var list = new List<object>(){1,2,"a","b"};
        var expected = new List<int>(){1,2};
        var actual = ListFilterer.GetIntegersFromList(list);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [Test]
    public void GetIntegersFromList_MixedValues_ShouldPass_2()
    {
        var list = new List<object>(){1,"a","b",0,15};
        var expected = new List<int>(){1,0,15};
        var actual = ListFilterer.GetIntegersFromList(list);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [Test]
    public void GetIntegersFromList_MixedValues_ShouldPass_3()
    {
        var list = new List<object>(){1,2,"aasf","1","123",123};
        var expected = new List<int>(){1,2,123};
        var actual = ListFilterer.GetIntegersFromList(list);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [Test]
    public void GetIntegersFromList_MixedValues_ShouldBeEmpty()
    {
        var list = new List<object>(){"a","b","1"};
        var expected = new List<int>();
        var actual = ListFilterer.GetIntegersFromList(list);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [Test]
    public void GetIntegersFromList_MixedValues_ShouldPass_5()
    {
        var list = new List<object>(){1,2,"a","b"};
        var expected = new List<int>(){1,2};
        var actual = ListFilterer.GetIntegersFromList(list);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    private static Random rnd = new Random();

    private static IEnumerable<int> solution(List<object> listOfItems) => listOfItems.Where(v => v is int).Cast<int>();

    private static object[] nonIntegers = new object[]
    {
        "Hello!!!!", "!!!! World!", "Raw", "Danger", "Is", "The", "Best", "PS2", "Game", "Disaster", "Report", "Is", "Alright", "I", "Guess",
    };

    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTest()
    {
        const int Tests = 100;
        const int TestCaseLength = 20;

        for (int i = 0; i < Tests; ++i)
        {
            List<object> testCase = new List<object>();
            for (int j = 0; j < TestCaseLength; ++j)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    testCase.Add(rnd.Next(0, 200));
                }
                else
                {
                    testCase.Add(nonIntegers[rnd.Next(0, nonIntegers.Length)]);
                }
            }

            IEnumerable<int> expected = solution(testCase);
            IEnumerable<int> actual = ListFilterer.GetIntegersFromList(testCase);

            Assert.AreEqual(expected, actual);
        }
    }
}