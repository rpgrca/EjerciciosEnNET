using Day23.Logic;
using static Day23.UnitTests.Constants;

namespace Day23.UnitTests;

public class UnstableDiffusionMust
{
    [Fact]
    public void Test1()
    {
        var sut = new UnstableDifusion(@".....
..##.
..#..
.....
..##.
.....");
        Assert.Equal(6, sut.Height);
        Assert.Equal(5, sut.Width);
        Assert.Equal(5, sut.Elves.Count);
        Assert.Equal(3, sut.CalculateEmptyGround());
    }
}