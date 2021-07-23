using System;
using Xunit;
using NumberToReversedArray.Logic;

namespace NumberToReversedArray.UnitTests
{
    public class DigitalizerMust
    {
        [Theory]
        [InlineData(35231, new long[] { 1, 3, 2, 5, 3 })]
        public void Test1(long originalNumber, long[] expectedOutput)
        {
            Assert.Equal(expectedOutput, Digitalizer.Digitalize(originalNumber));
        }
    }
}