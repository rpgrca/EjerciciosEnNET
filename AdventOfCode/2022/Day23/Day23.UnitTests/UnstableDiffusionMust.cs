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

    [Theory]
    [InlineData(1, "..##.\n.....\n..#..\n...#.\n..#..\n.....")]
    [InlineData(2, ".....\n..##.\n.#...\n....#\n.....\n..#..")]
    [InlineData(3, "..#..\n....#\n#....\n....#\n.....\n..#..")]
    public void ExecuteRoundsCorrectly_WhenUsingSimpleMap(int rounds, string expectedImage)
    {
        var sut = new UnstableDiffusion(SIMPLE_SAMPLE);
        sut.Round(rounds);
        Assert.Equal(expectedImage, sut.GetImage());
    }

    [Theory]
    [InlineData(1, "..............\n.......#......\n.....#...#....\n...#..#.#.....\n.......#..#...\n....#.#.##....\n..#..#.#......\n..#.#.#.##....\n..............\n....#..#......\n..............\n..............")]
    [InlineData(2, "..............\n.......#......\n....#.....#...\n...#..#.#.....\n.......#...#..\n...#..#.#.....\n.#...#.#.#....\n..............\n..#.#.#.##....\n....#..#......\n..............\n..............")]
    [InlineData(3, "..............\n.......#......\n.....#....#...\n..#..#...#....\n.......#...#..\n...#..#.#.....\n.#..#.....#...\n.......##.....\n..##.#....#...\n...#..........\n.......#......\n..............")]
    [InlineData(4, "..............\n.......#......\n......#....#..\n..#...##......\n...#.....#.#..\n.........#....\n.#...###..#...\n..#......#....\n....##....#...\n....#.........\n.......#......\n..............")]
    [InlineData(5, ".......#......\n..............\n..#..#.....#..\n.........#....\n......##...#..\n.#.#.####.....\n...........#..\n....##..#.....\n..#...........\n..........#...\n....#..#......\n..............")]
    [InlineData(10, ".......#......\n...........#..\n..#.#..#......\n......#.......\n...#.....#..#.\n.#......##....\n.....##.......\n..#........#..\n....#.#..#....\n..............\n....#..#..#...\n..............")]
    public void ExecuteRoundsCorrectly_WhenUsingSampleMap(int rounds, string expectedImage)
    {
        var sut = new UnstableDiffusion(SAMPLE_INPUT);
        sut.Round(rounds);
        Assert.Equal(expectedImage, sut.GetImage());
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new UnstableDiffusion(SAMPLE_INPUT);
        sut.Round(10);
        Assert.Equal(110, sut.CalculateEmptyGround());
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new UnstableDiffusion(PUZZLE_INPUT, 20);
        sut.Round(10);
        Console.WriteLine(sut.GetImage());
        Assert.True(3875 < sut.CalculateEmptyGround());
        Assert.Equal(3923, sut.CalculateEmptyGround());
    }
}