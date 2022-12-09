using Day7.Logic;
using Day7.Logic.Visitors;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class FinderMust
{
    [Fact]
    public void ReturnOne_WhenFindingAmountOfDirectoriesOfEmptyFileSystem()
    {
        var finder = new Finder("$ cd /\n$ ls");
        var sut = new DirectoryCountVisitor();
        finder.Accept(sut);
        Assert.Equal(1, sut.Count);
    }

    [Fact]
    public void ReturnTwo_WhenBrowsingAmountOfDirectoriesOfFileSystemWithOneDirectory()
    {
        var finder = new Finder("$ cd /\n$ ls\ndir a\n$ cd a\n$ ls");
        var sut = new DirectoryCountVisitor();
        finder.Accept(sut);
        Assert.Equal(2, sut.Count);
    }

    [Fact]
    public void ReturnTwo_WhenListingDirectoryInsideDirectoryButNeverBrowsingIt()
    {
        var finder = new Finder("$ cd /\n$ ls\ndir a");
        var sut = new DirectoryCountVisitor();
        finder.Accept(sut);
        Assert.Equal(2, sut.Count);
    }

    [Fact]
    public void ReturnCorrectAmountOfFiles()
    {
        var finder = new Finder("$ cd /\n$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\n$ cd a\n$ ls\n$ cd ..");
        var sut = new FileCountVisitor();
        finder.Accept(sut);
        Assert.Equal(2, sut.Count);
    }

    [Fact]
    public void ParseSampleDataCorrectly()
    {
        var finder = new Finder(SAMPLE_INPUT);
        var sut = new DirectoryCountVisitor();
        finder.Accept(sut);
        Assert.Equal(4, sut.Count);
        //Assert.Equal(10, sut.GetFileCount());
    }

    [Fact]
    public void CalculateDirectorySizeCorrectly()
    {
        var finder = new Finder(SAMPLE_INPUT);
        var sut = new DirectorySizeVisitor();
        finder.Accept(sut);
        Assert.Equal(48381165, sut.Size);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(95437, sut.GetSumOfTotalDirectoriesOfAtMost100000());
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new Finder(PUZZLE_INPUT);
        Assert.Equal(1778099, sut.GetSumOfTotalDirectoriesOfAtMost100000());
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new Finder(SAMPLE_INPUT);
        Assert.Equal(24933642, sut.GetSmallestDirectoryToDeleteToFreeEnoughSpace());
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new Finder(PUZZLE_INPUT);
        Assert.Equal(1623571, sut.GetSmallestDirectoryToDeleteToFreeEnoughSpace());
    }
}