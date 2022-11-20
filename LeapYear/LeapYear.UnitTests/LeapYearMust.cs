using LeapYear.Logic;

namespace LeapYear.UnitTests;

public class LeapYearCheckerMust
{
    [Fact]
    public void ReturnFalse_WhenYearIsNotDivisibleByFour()
    {
        var leapYear = new LeapYearChecker(1997);
        Assert.False(leapYear.Confirm());
    }

 /*   [Theory]
    [InlineData(1980)]
    [InlineData(1912)]
    public void ReturnTrue_WhenYearIsDivisibleByFour(int aLeapYear)
    {
        var leapYearChecker = new LeapYearChecker(aLeapYear);
        Assert.True(leapYearChecker.Confirm());
    }

    [Fact]
    public void ReturnFalse_WhenYearIsDivisibleBy100()
    {
        var leapYearChecker = new LeapYearChecker(1900);
        Assert.False(leapYearChecker.Confirm());
    }

    [Fact]
    public void ReturnTrue_WhenYearIsDivisibleBy400()
    {
        var leapYearChecker = new LeapYearChecker(2000);
        Assert.True(leapYearChecker.Confirm());
    }*/
}