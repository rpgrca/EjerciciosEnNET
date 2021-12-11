using System;
using Xunit;
using Day11.Logic;
using static Day11.UnitTests.Constants;

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

        [Theory]
        [InlineData(0, 0, 5)]
        [InlineData(9, 9, 6)]
        public void LoadsInputCorrectly(int x, int y, int expectedPower)
        {
            var sut = new OctopusCaveSimulation(SAMPLE_CAVE);
            Assert.Equal(expectedPower, sut.GetOctopusEnergyLevelAt(x, y));
        }

        [Theory]
        [InlineData(1, "34543\n40004\n50005\n40004\n34543")]
        public void ExecuteStepsCorrectly(int steps, string expectedMap)
        {
            const string map = "11111\n19991\n19191\n19991\n11111";

            var sut = new OctopusCaveSimulation(map);
            sut.Step(steps);
            Assert.Equal(expectedMap, sut.GetMap());
        }
    }
}