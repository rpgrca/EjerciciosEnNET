using Xunit;
using Codewars.ConnectTheDots.Logic;

namespace Codewars.ConnectTheDots.UnitTests
{
    public class ConnectorMust
    {
        [Theory]
        [InlineData(
            "           \n" +
            " a       b \n" +
            " e         \n" +
            "           \n" +
            " d       c \n" +
            "           \n",
            "           \n" +
            " ********* \n" +
            " *       * \n" +
            " *       * \n" +
            " ********* \n" +
            "           \n")]
        public void Test1(string input, string expectedValue)
        {
            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }
    }
}
