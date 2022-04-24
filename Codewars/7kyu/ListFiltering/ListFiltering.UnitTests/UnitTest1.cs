namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections;
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
  }
}