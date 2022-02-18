using Xunit;
using Qarater.Logic;

namespace Qaracter.UnitTests
{
    public class ArcQuestionMust
    {
        [Fact]
        public void SetRatioCorrectly()
        {
            var sut = new ArcQuestion.Builder()
                .WithRatioOf(6)
                .Build();

            Assert.Equal(6, sut.R);
        }

        [Fact]
        public void SetRectanglePerimeterCorrectly()
        {
            var sut = new ArcQuestion.Builder()
                .WithRectanglePerimeterOf(8)
                .Build();

            Assert.Equal(8, sut.RABC);
        }
    }
}
