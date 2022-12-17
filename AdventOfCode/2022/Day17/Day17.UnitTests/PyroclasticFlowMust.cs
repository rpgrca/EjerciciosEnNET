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
        Assert.Equal(expectedImage, sut.GetImage());
    }

    [Theory]
    [InlineData(1, "|..####.|\n+-------+")]
    [InlineData(2, @"|...#...|
|..###..|
|...#...|
|..####.|
+-------+")]
    public void MoveRocksCorrectly(int fallingRocks, string expectedImage)
    {
        var sut = new PyroclasticFlow(SAMPLE_INPUT, fallingRocks);
        Assert.Equal(expectedImage, sut.GetImage());
    }
}