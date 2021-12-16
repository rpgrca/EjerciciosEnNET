using System;
using Day16.Logic;
using Xunit;

namespace Day16.UnitTests
{
    public class TransmissionDecoderMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenTransmissionIsInvalid(string invalidTransmission)
        {
            var exception = Assert.Throws<ArgumentException>(() => new TransmissionDecoder(invalidTransmission));
            Assert.Equal("Invalid transmission", exception.Message);
        }
    }
}
