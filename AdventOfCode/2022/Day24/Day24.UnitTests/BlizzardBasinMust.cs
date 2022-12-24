using Day24.Logic;
using static Day24.UnitTests.Constants;

namespace Day24.UnitTests;

public class BlizzardBasinMust
{
    private const string SIMPLE_SAMPLE = @"#.#####
#.....#
#>....#
#.....#
#...v.#
#.....#
#####.#";

    [Fact]
    public void LoadInputCorrectly()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        Assert.Equal(7, sut.Height);
        Assert.Equal(7, sut.Width);
        Assert.Equal((1, 0), sut.Entrance);
        Assert.Equal((5, 6), sut.Exit);
    }
}