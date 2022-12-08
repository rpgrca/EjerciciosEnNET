using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class TreetopTreeHouseMust
{
    [Fact]
    public void Return9_WhenTreeIsVisibleFromTop()
    {
        var sut = new TreetopTreeHouse("303\n555\n653");
        Assert.Equal(9, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromLeft()
    {
        var sut = new TreetopTreeHouse("373\n355\n653");
        Assert.Equal(9, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromRight()
    {
        var sut = new TreetopTreeHouse("353\n653\n653");
        Assert.Equal(9, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromBottom()
    {
        var sut = new TreetopTreeHouse("353\n657\n623");
        Assert.Equal(9, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return8_WhenTreeIsNotVisible()
    {
        var sut = new TreetopTreeHouse("353\n657\n683");
        Assert.Equal(8, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheLeft()
    {
        var sut = new TreetopTreeHouse("2951\n2339\n9999");
        Assert.Equal(11, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheRight()
    {
        var sut = new TreetopTreeHouse("2951\n9332\n9999");
        Assert.Equal(11, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheTop()
    {
        var sut = new TreetopTreeHouse("129\n539\n939\n299");
        Assert.Equal(11, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new TreetopTreeHouse(SAMPLE_INPUT);
        Assert.Equal(21, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new TreetopTreeHouse(PUZZLE_INPUT);
        Assert.Equal(1854, sut.VisibleTreesFromOutside);
    }

    [Fact]
    public void Test1()
    {
        var sut = new TreetopTreeHouse("303\n555\n653");
        Assert.Equal(1, sut.BestScenicScore);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToTop()
    {
        var sut = new TreetopTreeHouse("199\n529\n939\n299");
        Assert.Equal(2, sut.BestScenicScore);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToRight()
    {
        var sut = new TreetopTreeHouse("2951\n9329\n9999");
        Assert.Equal(2, sut.BestScenicScore);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToLeft()
    {
        var sut = new TreetopTreeHouse("2951\n9239\n9999");
        Assert.Equal(2, sut.BestScenicScore);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToBottom()
    {
        var sut = new TreetopTreeHouse("199\n939\n529\n299");
        Assert.Equal(2, sut.BestScenicScore);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new TreetopTreeHouse(SAMPLE_INPUT);
        Assert.Equal(8, sut.BestScenicScore);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new TreetopTreeHouse(PUZZLE_INPUT);
        Assert.Equal(527340, sut.BestScenicScore);
    }
}