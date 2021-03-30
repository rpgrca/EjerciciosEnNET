using Xunit;
using PrimeNumber.Logic;

namespace PrimeNumber.UnitTests
{
    public class CompoundNumberMust
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ReturnFalse_WhenAskingIfAnInvalidNumberIsACompound(int invalidNumber) =>
            Assert.False(new Number(invalidNumber).CanBeClassifiedAs(A.CompoundNumber));

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
        public void ReturnFalse_WhenAskingIfAPrimeIsACompound(int primeNumber) =>
            Assert.False(new Number(primeNumber).CanBeClassifiedAs(A.CompoundNumber));

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(1048574)]
        public void ReturnTrue_WhenAskingIfACompoundNumberIsCompound(int compoundNumber) =>
            Assert.True(new Number(compoundNumber).CanBeClassifiedAs(A.CompoundNumber));
    }
}
