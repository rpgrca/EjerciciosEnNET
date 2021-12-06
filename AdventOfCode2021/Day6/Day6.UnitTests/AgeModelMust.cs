using System;
using Xunit;
using Day6.Logic;

namespace Day6.UnitTests
{
    public class AgeModelMust
    {
        [Fact]
        public void BeInitializedCorrectly()
        {
            var exception = Assert.Throws<ArgumentException>(() => new AgeModel(null));
            Assert.Equal("Invalid age list", exception.Message);
        }

        [Fact]
        public void Test1()
        {
            var sut = new AgeModel("3");
            Assert.Single(sut.Ages, 3);
        }
    }
}
