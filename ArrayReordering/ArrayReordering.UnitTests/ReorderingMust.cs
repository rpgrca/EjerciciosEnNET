using System;
using Xunit;
using ArrayReordering.Logic;

namespace ArrayReordering.UnitTests;

public class ReorderingMust
{
    [Fact]
    public void ReturnSameArray_WhenArrayIsEmpty()
    {
        var sut = new Reordering(Array.Empty<int>());
        Assert.Empty(sut.ReorderedArray);
    }
}