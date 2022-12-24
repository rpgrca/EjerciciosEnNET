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

    [Theory]
    [MemberData(nameof(LoadFeeder))]
    public void LoadInputCorrectly(string map, int expectedHeight, int expectedWidth, (int, int) expectedEntrance, (int, int) expectedExit)
    {
        var sut = new BlizzardBasin(map);
        Assert.Equal(expectedHeight, sut.Height);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedEntrance, sut.Entrance);
        Assert.Equal(expectedExit, sut.Exit);
    }

    public static IEnumerable<object[]> LoadFeeder()
    {
        yield return new object[] { SIMPLE_SAMPLE, 7, 7, (1, 0), (5, 6) };
        yield return new object[] { SAMPLE_INPUT, 6, 8, (1, 0), (6, 5) };
        yield return new object[] { PUZZLE_INPUT, 22, 152, (1, 0), (150, 21) };
    }

    [Fact]
    public void LoadBlizzardsCorrectly1()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        Assert.Collection(sut.Blizzards,
            b1 => Assert.Equal((1, 2, Direction.Right), b1),
            b2 => Assert.Equal((4, 4, Direction.Down), b2));
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 19)]
    [InlineData(PUZZLE_INPUT, 650 + 698 + 681 + 678)]
    public void LoadBlizzardsCorrectly2(string input, int expectedBlizzards)
    {
        var sut = new BlizzardBasin(input);
        Assert.Equal(expectedBlizzards, sut.Blizzards.Count);
    }

    [Fact]
    public void ReturnMapImageCorrectly()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        Assert.Equal(SAMPLE_INPUT, sut.GetImage());
    }
}