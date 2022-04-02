using Xunit;
using Day18.Logic;

namespace Day18.UnitTests
{
    public class RegularNumberMust
    {
        [Fact]
        public void ReturnTrue_WhenTwoDifferentInstancesHaveSameValue()
        {
            var value = 5.AsNumber();
            var sut = 5.AsNumber();

            Assert.Equal(value, sut);
        }

        [Fact]
        public void ReturnFalse_WhenTwoDifferentInstancesHaveDifferentValue()
        {
            var value = 5.AsNumber();
            var sut = 6.AsNumber();

            Assert.NotEqual(value, sut);
        }

        [Fact]
        public void ReturnFalse_WhenRegularNumberIsComparedWithSnailFishNumber()
        {
            var value = (5, 6).AsNumber();
            var sut = 6.AsNumber();

            Assert.False(sut.Equals(value));
        }
    }
}