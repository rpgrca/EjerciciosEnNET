using System;
using Day14.Logic;
using Xunit;

namespace Day14.UnitTests
{
    public class PolymerizationEquipmentMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidTemplate(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new PolymerizationEquipment(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }
    }
}
