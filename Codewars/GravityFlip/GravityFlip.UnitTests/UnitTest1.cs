using System;
using Xunit;
using GravityFlip.Logic;

namespace GravityFlip.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expectedResult = new int[] { 3, 2, 1, 2 };
            var sut = new GravityFlip.Logic.GravityFlip();
            Assert.Equal(new int[] {}, sut.State);
        }
    }
}
