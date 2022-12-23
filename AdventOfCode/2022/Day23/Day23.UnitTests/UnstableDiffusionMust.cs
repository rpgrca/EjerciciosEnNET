using Day23.Logic;
using static Day23.UnitTests.Constants;

namespace Day23.UnitTests;

public class UnstableDiffusionMust
{
    private const string SIMPLE_SAMPLE = @".....
..##.
..#..
.....
..##.
.....";

    [Fact]
    public void LoadDataCorrectly()
    {
        var sut = new UnstableDiffusion(SIMPLE_SAMPLE);
        Assert.Equal(6, sut.Height);
        Assert.Equal(5, sut.Width);
        Assert.Equal(5, sut.Elves.Count);
        Assert.Equal(3, sut.CalculateEmptyGround());
    }

    [Fact]
    public void ExecuteOneRoundCorrectly()
    {
        var sut = new UnstableDiffusion(SIMPLE_SAMPLE);
        sut.Round(1);
        Assert.Equal(@"..##.
.....
..#..
...#.
..#..
.....", sut.GetImage());
    }

    [Fact]
    public void ExecuteTwoRoundsCorrectly()
    {
        var sut = new UnstableDiffusion(SIMPLE_SAMPLE);
        sut.Round(2);
        Assert.Equal(@".....
..##.
.#...
....#
.....
..#..", sut.GetImage());
    }
}