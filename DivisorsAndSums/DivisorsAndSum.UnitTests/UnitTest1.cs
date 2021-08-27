using System;
using Xunit;
using DivisorsAndSum.Logic;

namespace DivisorsAndSum.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new XYZ(1);
            Assert.Equal("1 + 2 + 3 = 6", sut.Result);
        }

        [Fact]
        public void Test2()
        {
            var sut = new XYZ(2);
            Assert.Equal("1 + 2 + 3 = 6\n1 + 2 + 4 + 7 + 14 = 28", sut.Result);
        }
    }
}
