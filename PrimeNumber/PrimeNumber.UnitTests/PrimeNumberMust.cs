using Xunit;
using PrimeNumber.Logic;

namespace PrimeNumber.UnitTests
{
    public class PrimeNumberMust
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(7)]
        [InlineData(19)]
        [InlineData(23)]
        [InlineData(991)]
        [InlineData(997)]
        [InlineData(6863)]
        [InlineData(7919)]
        [InlineData(1043857)]
        [InlineData(1048573)]
        public void ReturnTrue_WhenAskingIfAPrimeIsAPrime(int primeNumber) =>
            Assert.True(new Number(primeNumber).CanBeClassifiedAs(A.PrimeNumber));

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(1048574)]
        public void ReturnFalse_WhenAskingIfACompositeNumberIsPrime(int compoundNumber) =>
            Assert.False(new Number(compoundNumber).CanBeClassifiedAs(A.PrimeNumber));
    }
}