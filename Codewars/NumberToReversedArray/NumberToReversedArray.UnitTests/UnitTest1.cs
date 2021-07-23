using System;
using Xunit;
using NumberToReversedArray.Logic;

namespace NumberToReversedArray.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(new long[] { 1, 3, 2, 5, 3 }, Digitalizer.Digitalize(35231));
        }
    }
}
