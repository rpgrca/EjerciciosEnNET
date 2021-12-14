using System;
using Xunit;
using Day14.Logic;
using static Day14.UnitTests.Constants;

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

        [Theory]
        [InlineData(SAMPLE_INPUT, "NNCB", 16)]
        [InlineData(REAL_INPUT, "VPPHOPVVSFSVFOCOSBKF", 100)]
        public void BeInitializedCorrectly_WhenCorrectInputIsSupplied(string input, string expectedTemplate, int expectedRulesCount)
        {
            var sut = new PolymerizationEquipment(input);
            Assert.Equal(expectedTemplate, sut.PolymerTemplate);
            Assert.Equal(expectedRulesCount, sut.GetPairInsertionRulesCount());
        }

        [Theory]
        [InlineData(1, "NCNBCHB")]
        [InlineData(2, "NBCCNBBBCBHCB")]
        [InlineData(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
        [InlineData(4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
        public void Test1(int steps, string expectedTemplate)
        {
            var sut = new PolymerizationEquipment(SAMPLE_INPUT);
            sut.Step(steps);
            Assert.Equal(expectedTemplate, sut.PolymerTemplate);
        }
    }
}
