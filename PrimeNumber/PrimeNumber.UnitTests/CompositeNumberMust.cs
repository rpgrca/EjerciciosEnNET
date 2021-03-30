using System.Linq;
using Xunit;
using PrimeNumber.Logic;

namespace PrimeNumber.UnitTests
{
    public class CompositeNumberMust
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ReturnFalse_WhenAskingIfAnInvalidNumberIsAComposite(int invalidNumber) =>
            Assert.False(new Number(invalidNumber).CanBeClassifiedAs(A.CompositeNumber));

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
        public void ReturnFalse_WhenAskingIfAPrimeIsAComposite(int primeNumber) =>
            Assert.False(new Number(primeNumber).CanBeClassifiedAs(A.CompositeNumber));

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(1048574)]
        public void ReturnTrue_WhenAskingIfACompositeNumberIsComposite(int compositeNumber) =>
            Assert.True(new Number(compositeNumber).CanBeClassifiedAs(A.CompositeNumber));

/*
        [Fact]
        public void CalculateCompositeNumbersIn1To1000000()
        {
            var compositeNumbers = Enumerable
                .Range(1, 1000000)
                .Where(p => new Number(p).CanBeClassifiedAs(A.CompositeNumber))
                .ToList();
        }*/
    }
}