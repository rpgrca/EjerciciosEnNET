using System.Runtime.InteropServices;
using System.Reflection;
using System;
using Xunit;
using Day11.Logic;

namespace Day11.UnitTests
{
    public class OctopusCaveSimulationMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenInitializedWithInvalidInput(string invalidInput)
        {
            var exception = Assert.Throws<ArgumentException>(() => new OctopusCaveSimulation(invalidInput));
            Assert.Equal("Invalid input", exception.Message);
        }
    }
}
