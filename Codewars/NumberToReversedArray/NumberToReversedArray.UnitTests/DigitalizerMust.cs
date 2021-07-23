using System;
using Xunit;
using NumberToReversedArray.Logic;

namespace NumberToReversedArray.UnitTests
{
    public class DigitalizerMust
    {
        [Theory]
        [InlineData(35231, new long[] { 1, 3, 2, 5, 3 })]
        [InlineData(0, new long[] { 0 })]
        [InlineData(100, new long[] { 0, 0, 1 })]
        public void ReturnReversedArrayOfDigits_WhenValueIsGiven(long originalNumber, long[] expectedOutput) =>
            Assert.Equal(expectedOutput, Digitalizer.Digitalize(originalNumber));
    }
}