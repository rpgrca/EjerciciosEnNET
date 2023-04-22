namespace SortedSearch.UnitTests;

using SortedSearch.Logic;

public class SortedSearchMust
{
    [Fact]
    public void SolveExample()
    {
        Assert.Equal(2, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4));
    }
}