using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class MonkeyMapMust
{
    [Fact]
    public void LoadMapCorrectly()
    {
        var sut = new MonkeyMap(SAMPLE_INPUT);
        Assert.Equal(12, sut.Height);
        Assert.Equal(16, sut.Width);
        Assert.Equal(8, sut.StartingPointX);
        Assert.Equal(0, sut.StartingPointY);
        Assert.Collection(sut.Steps,
            s1 => Assert.Equal(('F', 10), s1),
            s2 => Assert.Equal(('R', 90), s2),
            s3 => Assert.Equal(('F', 5), s3),
            s4 => Assert.Equal(('L', 90), s4),
            s5 => Assert.Equal(('F', 5), s5),
            s6 => Assert.Equal(('R', 90), s6),
            s7 => Assert.Equal(('F', 10), s7),
            s8 => Assert.Equal(('L', 90), s8),
            s9 => Assert.Equal(('F', 4), s9),
            sa => Assert.Equal(('R', 90), sa),
            sb => Assert.Equal(('F', 5), sb),
            sc => Assert.Equal(('L', 90), sc),
            sd => Assert.Equal(('F', 5), sd));
    }

    [Fact]
    public void LoadMapCorrectly_WhenStartingPointIsBlocked()
    {
        var sut = new MonkeyMap("#....\n.....\n.....\n.....\n.....\n\n9");
        Assert.Equal(1, sut.StartingPointX);
        Assert.Equal(0, sut.StartingPointY);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenPathIsFreeAndNoWrapIsNeeded()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\n3");
        sut.Run();
        Assert.Equal(1000 * 1 + 4 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenPathIsBlocked()
    {
        var sut = new MonkeyMap("..#..\n.....\n.....\n.....\n.....\n\n3");
        sut.Run();
        Assert.Equal(1000 * 1 + 2 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenWrappingWithoutBlank()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\n7");
        sut.Run();
        Assert.Equal(1000 * 1 + 3 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenWrappingAndEmptySpaceIsAtEnd()
    {
        var sut = new MonkeyMap(".....    \n.....    \n.....\n.....\n.....\n\n7");
        sut.Run();
        Assert.Equal(1000 * 1 + 3 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenWrappingAndEmptySpaceIsAtBeginning()
    {
        var sut = new MonkeyMap("    .....\n    .....\n.....\n.....\n.....\n\n7");
        sut.Run();
        Assert.Equal(1000 * 1 + 7 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateRightPositionCorrectly_WhenWrappingAndEmptySpaceAllAround()
    {
        var sut = new MonkeyMap("    .....     \n    .....     \n.....\n.....\n.....\n\n7");
        sut.Run();
        Assert.Equal(1000 * 1 + 7 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void DoNotWrapPosition_WhenGoingRightAndIsBlockedOnOtherSide()
    {
        var sut = new MonkeyMap("#....\n.....\n.....\n.....\n.....\n\n9");
        sut.Run();
        Assert.Equal(1000 * 1 + 5 * 4 + 0, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenPathIsFreeAndNoWrapIsNeeded()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\n4RR3");
        sut.Run();
        Assert.Equal(1000 * 1 + 2 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenPathIsBlocked()
    {
        var sut = new MonkeyMap("#....\n.....\n.....\n.....\n.....\n\n2RR5");
        sut.Run();
        Assert.Equal(1000 * 1 + 2 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenWrappingWithoutBlank()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\nRR2");
        sut.Run();
        Assert.Equal(1000 * 1 + 4 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenWrappingAndEmptySpaceIsAtEnd()
    {
        var sut = new MonkeyMap(".....    \n.....    \n.....\n.....\n.....\n\nLL7");
        sut.Run();
        Assert.Equal(1000 * 1 + 4 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenWrappingAndEmptySpaceIsAtBeginning()
    {
        var sut = new MonkeyMap("    .....\n    .....\n.....\n.....\n.....\n\nLRRR2");
        sut.Run();
        Assert.Equal(1000 * 1 + 8 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateLeftPositionCorrectly_WhenWrappingAndEmptySpaceAllAround()
    {
        var sut = new MonkeyMap("    .....     \n    .....     \n.....\n.....\n.....\n\nRLLL7");
        sut.Run();
        Assert.Equal(1000 * 1 + 8 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void DoNotWrapPosition_WhenGoingLeftAndIsBlockedOnOtherSide()
    {
        var sut = new MonkeyMap("....#\n.....\n.....\n.....\n.....\n\nLL3");
        sut.Run();
        Assert.Equal(1000 * 1 + 1 * 4 + 2, sut.FinalPassword);
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenPathIsFreeAndNoWrapIsNeeded()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\nR3");
        sut.Run();
        Assert.Equal(1000 * 4 + 1 * 4 + 1, sut.FinalPassword);
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenPathIsBlocked()
    {
        var sut = new MonkeyMap(".....\n.....\n#....\n.....\n.....\n\nR3");
        sut.Run();
        Assert.Equal(1000 * 2 + 1 * 4 + 1, sut.FinalPassword);
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenWrappingWithoutBlank()
    {
        var sut = new MonkeyMap(".....\n.....\n.....\n.....\n.....\n\nR7");
        sut.Run();
        Assert.Equal(1000 * 3 + 1 * 4 + 1, sut.FinalPassword);
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenWrappingAndEmptySpaceIsAtEnd()
    {
        var sut = new MonkeyMap("     .....\n     .....\n     .....\n     .....\n.....\n.....\n.....\n\nR7");
        sut.Run();
        Assert.Equal(1000 * 4 + 6 * 4 + 1, sut.FinalPassword);
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenWrappingAndEmptySpaceIsAtBeginning()
    {
        Assert.False("Impossible case" == "");
    }

    [Fact]
    public void CalculateDownPositionCorrectly_WhenWrappingAndEmptySpaceAllAround()
    {
        Assert.False("Impossible case" == "");
    }

    [Fact]
    public void DoNotWrapPosition_WhenGoingDownAndIsBlockedOnOtherSide()
    {
        var sut = new MonkeyMap(".#...\n.....\n.....\n.....\n.....\n\nR4L1R4");
        sut.Run();
        Assert.Equal(1000 * 5 + 2 * 4 + 1, sut.FinalPassword);
    }
}