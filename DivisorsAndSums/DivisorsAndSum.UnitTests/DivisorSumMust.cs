using Xunit;
using DivisorsAndSum.Logic;

namespace DivisorsAndSum.UnitTests
{
    public class DivisorSumMust
    {
        [Fact]
        public void ReturnEquationFor6_WhenAskedForFirstValueFulfillingCondition()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(1)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6", sut.Result);
        }

        [Fact]
        public void ReturnEquationsFor6And28_WhenAskedForFirstTwoValuesFulfillingCondition()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(2)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28", sut.Result);
        }

        [Fact]
        public void Test3()
        {
            var sut = new DivisorSum.Builder()
                .UpTo(3)
                .Build();

            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28\n1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248 = 496", sut.Result);
        }
    }
}
