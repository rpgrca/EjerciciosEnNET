using System;
using Xunit;
using ArrayReordering.Logic;

namespace ArrayReordering.UnitTests;

public class ReorderingMust
{
    [Fact]
    public void ReturnSameArray_WhenArrayIsEmpty()
    {
        var sut = CreateSubjectUnderTest(Array.Empty<int>());
        Assert.Empty(sut.ReorderedArray);
    }

    private static Reordering CreateSubjectUnderTest(int[] values) =>
        new Reordering.Builder()
            .Using(new FromBehindEveryOtherAlgorithm())
            .Sorting(values)
            .Build();

    [Fact]
    public void ReturnSameArray_WhenArrayHasOneElement()
    {
        var sut = CreateSubjectUnderTest(new int[] { 1 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(1, p1));
    }

    [Fact]
    public void ReorderTwoElementArrayCorrectly()
    {
        var sut = CreateSubjectUnderTest(new int[] { 1, 2 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(2, p1),
            p2 => Assert.Equal(1, p2));
    }

    [Fact]
    public void ReorderThreeElementArrayCorrectly()
    {
        var sut = CreateSubjectUnderTest(new int[] { 1, 2, 3 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(3, p1),
            p2 => Assert.Equal(1, p2),
            p3 => Assert.Equal(2, p3));
    }

    [Fact]
    public void ReorderFiveElementArrayCorrectly()
    {
        var sut = CreateSubjectUnderTest(new int[] { 1, 2, 3, 4, 5 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(5, p1),
            p2 => Assert.Equal(3, p2),
            p3 => Assert.Equal(1, p3),
            p4 => Assert.Equal(2, p4),
            p5 => Assert.Equal(4, p5));
    }

    [Fact]
    public void ReorderSixElementArrayCorrectly()
    {
        var sut = CreateSubjectUnderTest(new int[] { 1, 2, 3, 4, 5, 6 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(6, p1),
            p2 => Assert.Equal(4, p2),
            p3 => Assert.Equal(2, p3),
            p4 => Assert.Equal(1, p4),
            p5 => Assert.Equal(3, p5),
            p6 => Assert.Equal(5, p6));
    }

    [Fact]
    public void ReorderArrayWithRandomSortedValues()
    {
        var sut = CreateSubjectUnderTest(new int[] { 2, 4, 6, 8, 10 });
        Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(10, p1),
            p2 => Assert.Equal(6, p2),
            p3 => Assert.Equal(2, p3),
            p4 => Assert.Equal(4, p4),
            p5 => Assert.Equal(8, p5));
    }

    [Fact]
    public void ReorderArrayWithDuplicatedValues()
     {
         var sut = CreateSubjectUnderTest(new int[] { 1, 1, 2, 2, 3, 3 });
         Assert.Collection(sut.ReorderedArray,
            p1 => Assert.Equal(3, p1),
            p2 => Assert.Equal(2, p2),
            p3 => Assert.Equal(1, p3),
            p4 => Assert.Equal(1, p4),
            p5 => Assert.Equal(2, p5),
            p6 => Assert.Equal(3, p6));
     }
}