using Xunit;
using Day19.Logic;

namespace Day19.UnitTests
{

    public class EuclideanDistanceMust
    {
        [Fact]
        public void CalculateDistanceBetweenTwoBeaconsCorrectly()
        {
            var sut1 = new EuclideanDistance((-618, -824, -621), (-537, -823, -458));
            var sut2 = new EuclideanDistance((686, 422, 578), (605, 423, 415));

            Assert.Equal(sut1.Distance, sut2.Distance);
        }
    }
}