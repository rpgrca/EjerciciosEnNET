using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class CampCleanupMust
{
    [Fact]
    public void ReturnsNoFullyContainedSections()
    {
        var sut = new CampCleanup("2-4,6-8");
        Assert.Equal(0, sut.FullyContainedSections);
    }

    [Theory]
    [InlineData("5-7,7-9")]
    public void ReturnsOneFullyContainedSection(string input)
    {
        var sut = new CampCleanup(input);
        Assert.Equal(1, sut.FullyContainedSections);
    }
}