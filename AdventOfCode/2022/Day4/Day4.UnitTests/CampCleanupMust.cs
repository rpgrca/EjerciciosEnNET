using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class CampCleanupMust
{
    [Theory]
    [InlineData("2-4,6-8", 0)]
    [InlineData("5-7,7-9", 0)]
    [InlineData("2-6,4-8", 0)]
    [InlineData("6-6,4-6", 1)]
    [InlineData("2-4,6-8\n2-3,4-5\n5-7,7-9", 0)]
    [InlineData("2-8,3-7\n6-6,4-6", 2)]
    public void CalculateFullyContainedSectionsCorrectly(string input, int expectedSections)
    {
        var sut = new CampCleanup(input);
        Assert.Equal(expectedSections, sut.FullyContainedSections);
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new CampCleanup(SAMPLE_INPUT);
        Assert.Equal(2, sut.FullyContainedSections);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new CampCleanup(PUZZLE_INPUT);
        Assert.Equal(490, sut.FullyContainedSections);
    }
}