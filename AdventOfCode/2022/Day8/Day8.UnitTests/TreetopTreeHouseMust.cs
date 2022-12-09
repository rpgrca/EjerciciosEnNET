using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class TreetopTreeHouseMust
{
    [Fact]
    public void Return9_WhenTreeIsVisibleFromTop()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("303\n555\n653");
        Assert.Equal(9, sut.Result);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromLeft()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("373\n355\n653");
        Assert.Equal(9, sut.Result);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromRight()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("353\n653\n653");
        Assert.Equal(9, sut.Result);
    }

    [Fact]
    public void Return9_WhenTreeIsVisibleFromBottom()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("353\n657\n623");
        Assert.Equal(9, sut.Result);
    }

    [Fact]
    public void Return8_WhenTreeIsNotVisible()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("353\n657\n683");
        Assert.Equal(8, sut.Result);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheLeft()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("2951\n2339\n9999");
        Assert.Equal(11, sut.Result);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheRight()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("2951\n9332\n9999");
        Assert.Equal(11, sut.Result);
    }

    [Fact]
    public void Return11_WhenTreeHasInternalTreeCoveringItToTheTop()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle("129\n539\n939\n299");
        Assert.Equal(11, sut.Result);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle(SAMPLE_INPUT);
        Assert.Equal(21, sut.Result);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = TreetopTreeHouse.CreateForFirstPuzzle(PUZZLE_INPUT);
        Assert.Equal(1854, sut.Result);
    }

    [Fact]
    public void Test1()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle("303\n555\n653");
        Assert.Equal(1, sut.Result);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToTop()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle("199\n529\n939\n299");
        Assert.Equal(2, sut.Result);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToRight()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle("2951\n9329\n9999");
        Assert.Equal(2, sut.Result);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToLeft()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle("2951\n9239\n9999");
        Assert.Equal(2, sut.Result);
    }

    [Fact]
    public void ReturnScenicViewCorrectly_WhenVisionIsProlongedToBottom()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle("199\n939\n529\n299");
        Assert.Equal(2, sut.Result);
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle(SAMPLE_INPUT);
        Assert.Equal(8, sut.Result);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = TreetopTreeHouse.CreateForSecondPuzzle(PUZZLE_INPUT);
        Assert.Equal(527340, sut.Result);
    }
}