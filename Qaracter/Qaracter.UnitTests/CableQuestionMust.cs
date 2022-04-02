using Qaracter.Logic;
using Xunit;

namespace Qaracter.UnitTests
{
    public class CableQuestionMust
    {
        [Fact]
        public void BeInitializedCorrectly()
        {
            var sut = new CableQuestion(50, 80, 10);
            Assert.Equal(50, sut.PoleHeight);
            Assert.Equal(80, sut.CableLength);
            Assert.Equal(10, sut.HeightAtCenter);
        }

        [Fact]
        public void SolvePuzzle()
        {
            var sut = new CableQuestion(50, 80, 10);
            Assert.Equal(0, sut.PoleDistance);
        }
    }
}
