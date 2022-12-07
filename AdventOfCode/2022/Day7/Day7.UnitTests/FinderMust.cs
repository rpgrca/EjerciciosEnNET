using Day7.Logic;

namespace Day7.UnitTests;

public class FinderMust
{
    [Fact]
    public void ReturnOne_WhenFindingAmountOfDirectoriesOfEmptyFileSystem()
    {
        var sut = new Finder("$ cd /\n$ ls");
        Assert.Equal(1, sut.GetDirectoryCount("/"));
    }

    [Fact]
    public void ReturnOne_WhenBrowsingAmountOfDirectoriesOfFileSystemWithOneDirectory()
    {
        var sut = new Finder("$ cd /\n$ ls\ndir a\n$ cd a\n$ ls");
        Assert.Equal(2, sut.GetDirectoryCount("/"));
    }
}