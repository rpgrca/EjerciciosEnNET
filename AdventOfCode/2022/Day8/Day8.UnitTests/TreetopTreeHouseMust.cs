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

    [Fact]
    public void Test2()
    {
        var sut = new TreetopTreeHouse("373\n655\n653");
        Assert.Equal(8, sut.VisibleTreesFromOutside);
    }

}