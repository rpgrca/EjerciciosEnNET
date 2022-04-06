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

    [Fact]
    public void ReturnSameArray_WhenArrayHasOneElement()
    {
        var sut = new Reordering(new int[] { 1 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(1, p1));
    }

    [Fact]
    public void ReorderTwoElementArrayCorrectly()
    {
        var sut = new Reordering(new int[] { 1, 2 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(2, p1),
            p2 => Assert.Equal(1, p2));
    }
}