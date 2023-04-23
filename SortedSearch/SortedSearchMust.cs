namespace SortedSearch.UnitTests;

using SortedSearch.Logic;

public class SortedSearchMust
{
    [Fact]
    public void SolveShortArray_WhenValueIsInArray()
    {
        Assert.Equal(0, SortedSearch.CountNumbers(new int[] { 2 }, 2));
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(1, 0)]
    public void SolveShortArray_WhenValueIsNotInArray(int lessThan, int expectedResult)
    {
       Assert.Equal(expectedResult, SortedSearch.CountNumbers(new int[] { 2 }, lessThan));
    }

    [Fact]
    public void SolveExample()
    {
        Assert.Equal(2, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }

    [Fact]
    public void SolveLargeExample()
    {
        var array = Enumerable.Range(1, 100000).Select(p => p).ToArray();
        Assert.Equal(36999, SortedSearch.CountNumbers(array, 37000));
    }

    [Theory]
    [InlineData(3, 1)]
    [InlineData(36001, 18000)]
    public void SolveLargeExample_WhenValueIsNotInArray(int lessThan, int expectedResult)
    {
        var array = Enumerable.Range(1, 100000).Select(p => p * 2).ToArray();
        Assert.Equal(expectedResult, SortedSearch.CountNumbers(array, lessThan));
    }
}