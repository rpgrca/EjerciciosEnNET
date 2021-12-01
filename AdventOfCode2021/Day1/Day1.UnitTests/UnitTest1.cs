using System;
using Xunit;
using Day1.Logic;

namespace Day1.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const string DEPTHS = @"199
200
208
210
200
207
240
269
260
263";

            var sut = new Xyz(DEPTHS);
            Assert.Equal(7, sut.Increments);
        }
    }
}
