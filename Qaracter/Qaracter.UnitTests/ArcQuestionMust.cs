using Xunit;
using Qarater.Logic;
using System;

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

            Assert.Equal(8, sut.RAC);
        }

        [Fact]
        public void CalculateQuarterOfCirclePerimeter()
        {
            var sut = GetSubjectUnderTest();
            Assert.Equal(Math.PI * 3, sut.ST);
        }

        private static ArcQuestion GetSubjectUnderTest() =>
            new ArcQuestion.Builder()
                .WithRatioOf(6)
                .WithRectanglePerimeterOf(8)
                .Build();

        [Fact]
        public void CalculateRectangleBisector()
        {
            var sut = GetSubjectUnderTest();
            Assert.Equal(6, sut.AC);
        }

        [Fact]
        public void CalculateShadowedPerimeterCorrectly()
        {
            var sut = GetSubjectUnderTest();
            Assert.Equal(10 + 3 * Math.PI, sut.Perimeter);
        }
    }
}
