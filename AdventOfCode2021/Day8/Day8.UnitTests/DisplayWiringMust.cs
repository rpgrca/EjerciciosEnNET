using System;
using Xunit;
using Day8.Logic;

namespace Day8.UnitTests
{
    public class DisplayWiringMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInvalidWiringIsUsed(string invalidWiring)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DisplayWiring(invalidWiring));
            Assert.Equal("Invalid wiring", exception.Message);
        }

        [Theory]
        [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 1)]
        [InlineData(@"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 2)]
        public void Test1(string wiring, int expectedSets)
        {
            var sut = new DisplayWiring(wiring);
            Assert.Equal(expectedSets, sut.TotalScannings);
        }
    }
}
