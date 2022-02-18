using System.Runtime.InteropServices;
using System;
using Xunit;
using Qarater.Logic;

namespace Qaracter.UnitTests
{
    public class ArcQuestionMust
    {
        [Fact]
        public void SetRatioCorrectly()
        {
            var sut = new ArcQuestion
            {
                R = 6
            };

            Assert.Equal(6, sut.R);
        }

        [Fact]
        public void SetRectanglePerimeterCorrectly()
        {
            var sut = new ArcQuestion
            {
                RABC = 8
            };

            Assert.Equal(8, sut.RABC);
        }
    }
}
