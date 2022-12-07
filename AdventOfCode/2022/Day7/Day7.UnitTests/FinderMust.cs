using Day7.Logic;

namespace Day7.UnitTests;

public class FinderMust
{
    [Fact]
    public void ReturnZero_WhenFindingAmountOfDirectoriesOfEmptyFileSystem()
    {
        var sut = new Finder("$ cd /\n$ ls");
        Assert.Equal(1, sut.GetDirectoryCount());
    }
}