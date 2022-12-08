using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class TreetopTreeHouseMust
{
    [Fact]
    public void Test1()
    {
        var sut = new TreetopTreeHouse("303\n255\n653");
        Assert.Equal(9, sut.VisibleTreesFromOutside);
    }
}