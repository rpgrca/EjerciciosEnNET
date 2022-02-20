using Qaracter.Logic;
using Xunit;

namespace Qaracter.UnitTests
{
    public class CableQuestionMust
    {
        [Fact]
        public void InitializePoleHeightCorrectly()
        {
            var sut = new CableQuestion(50, 80);
            Assert.Equal(50, sut.PoleHeight);
        }

        [Fact]
        public void InitializeCableLengthCorrectly()
        {
            var sut = new CableQuestion(50, 80);
            Assert.Equal(80, sut.CableLength);
        }
    }
}