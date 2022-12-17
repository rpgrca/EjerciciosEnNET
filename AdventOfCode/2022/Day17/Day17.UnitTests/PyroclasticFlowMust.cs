using Day17.Logic;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class PyroclasticFlowMust
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 4)]
    public void CalculateHeightCorrectly_WhenDeterminedAmountOfRocksFallToTheLeft(int fallingRocks, int expectedHeight)
    {
        var sut = new PyroclasticFlow("<", fallingRocks);
        Assert.Equal(expectedHeight, sut.GetHeight());
    }

    [Theory]
    [InlineData(1, "|####...|\n+-------+")]
    [InlineData(2,
@"|.#.....|
|###....|
|.#.....|
|####...|
+-------+")]
    public void RepresentChamberCorrectly(int fallingRocks, string expectedImage)
    {
        var sut = new PyroclasticFlow("<", fallingRocks);
        Assert.Equal(expectedImage, sut.GetChamber());
    }

    [Theory]
    [InlineData(1, "|..####.|\n+-------+")]
    [InlineData(2, @"|...#...|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(3, @"|..#....|
|..#....|
|####...|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(4, @"|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(5, @"|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(6, @"|.####..|
|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(7, @"|..#....|
|.###...|
|..#....|
|.####..|
|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(8, @"|.....#.|
|.....#.|
|..####.|
|.###...|
|..#....|
|.####..|
|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(9, @"|....#..|
|....#..|
|....##.|
|....##.|
|..####.|
|.###...|
|..#....|
|.####..|
|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    [InlineData(10, @"|....#..|
|....#..|
|....##.|
|##..##.|
|######.|
|.###...|
|..#....|
|.####..|
|....##.|
|....##.|
|....#..|
|..#.#..|
|..#.#..|
|#####..|
|..###..|
|...#...|
|..####.|
+-------+")]
    public void MoveRocksCorrectly(int fallingRocks, string expectedImage)
    {
        var sut = new PyroclasticFlow(SAMPLE_INPUT, fallingRocks);
        Assert.Equal(expectedImage, sut.GetChamber());
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new PyroclasticFlow(SAMPLE_INPUT, 2022);
        Assert.Equal(3068, sut.GetHeight());
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new PyroclasticFlow(PUZZLE_INPUT, 2022);
        Assert.Equal(3224, sut.GetHeight());
    }
}