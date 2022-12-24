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
            b1 =>
            {
                Assert.Equal(1, b1.X);
                Assert.Equal(2, b1.Y);
                Assert.Equal('>', b1.Direction);
            },
            b2 =>
            {
                Assert.Equal(4, b2.X);
                Assert.Equal(4, b2.Y);
                Assert.Equal('v', b2.Direction);
            });
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

    [Fact]
    public void ExecuteOneRoundCorrectly_WhenUsingSimpleMap()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        sut.MoveBlizzards();
        Assert.Equal(@"#.#####
#.....#
#.>...#
#.....#
#.....#
#...v.#
#####.#", sut.GetImage());
    }

    [Fact]
    public void WrapFromBottomToTopCorrectly()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.#####
#...v.#
#..>..#
#.....#
#.....#
#.....#
#####.#", sut.GetImage());
    }

    [Fact]
    public void ExecuteOverlapCorrectly()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.#####
#.....#
#...2.#
#.....#
#.....#
#.....#
#####.#", sut.GetImage());
    }

    [Fact]
    public void ExecuteDeoverlapCorrectly()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.#####
#.....#
#....>#
#...v.#
#.....#
#.....#
#####.#", sut.GetImage());
    }

    [Fact]
    public void WrapFromRightToLeftCorrectly()
    {
        var sut = new BlizzardBasin(SIMPLE_SAMPLE);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.#####
#.....#
#>....#
#.....#
#...v.#
#.....#
#####.#", sut.GetImage());
    }

    [Fact]
    public void Test1()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        Assert.Equal(@"#.######
#.>3.<.#
#<..<<.#
#>2.22.#
#>v..^<#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test2()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.######
#.2>2..#
#.^22^<#
#.>2.^>#
#.>..<.#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test3()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.######
#<^<22.#
#.2<.2.#
#><2>..#
#..><..#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test4()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.######
#.<..22#
#<<.<..#
#<2.>>.#
#.^22^.#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test5()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        Assert.Equal(@"#.######
#2.v.<>#
#<.<..<#
#.^>^22#
#.2..2.#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test6()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();

        Assert.Equal(@"#.######
#>2.<.<#
#.2v^2<#
#>..>2>#
#<....>#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test7()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();

        Assert.Equal(@"#.######
#.22^2.#
#<v.<2.#
#>>v<>.#
#>....<#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test8()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();

        Assert.Equal(@"#.######
#.<>2^.#
#..<<.<#
#.22..>#
#.2v^2.#
######.#", sut.GetImage());
    }

    [Fact]
    public void Test18()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();
        sut.MoveBlizzards();

        Assert.Equal(@"#.######
#>2.<.<#
#.2v^2<#
#>..>2>#
#<....>#
######.#", sut.GetImage());
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new BlizzardBasin(SAMPLE_INPUT);
        var result = sut.FindShortestPath();
        Assert.Equal(18, result);
    }
}