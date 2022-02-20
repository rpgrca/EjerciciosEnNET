using Qaracter.Logic;
using Xunit;

namespace Qaracter.UnitTests
{
    public class CableQuestionMust
    {
        [Fact]
        public void BeInitializedCorrectly()
        {
            var sut = new CableQuestion(50);
            Assert.Equal(50, sut.PoleHeight);
        }
    }
}