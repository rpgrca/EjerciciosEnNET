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
    }
}