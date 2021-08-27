using Xunit;
using DivisorsAndSum.Logic;

namespace DivisorsAndSum.UnitTests
{
    public class DivisorSumMust
    {
        [Fact]
        public void ReturnEquationFor6_WhenAskedForFirstValueFulfillingCondition()
        {
            var sut = new DivisorSum(1);
            Assert.Equal("1 + 2 + 3 = 6", sut.Result);
        }

        [Fact]
        public void ReturnEquationsFor6And28_WhenAskedForFirstTwoValuesFulfillingCondition()
        {
            var sut = new DivisorSum(2);
            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28", sut.Result);
        }
    }
}