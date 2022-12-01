namespace Day1.UnitTests;

using Day1.Logic;
using static Constants;

public class CaloryCounterMust
{
    [Fact]
    public void Test1()
    {
        var sut = new CaloryCounter(SAMPLE_INPUT);
        Assert.Equal(24000, sut.MostCaloriesCarriedBySingleElf);
    }
}