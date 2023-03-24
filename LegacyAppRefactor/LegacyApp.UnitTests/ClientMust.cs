namespace LegacyApp.UnitTests
{
    public class ClientMust
    {
        [Fact]
        public void SetIdCorrectly()
        {
            const int anyId = 1;
            var sut = new Client
            {
                Id = anyId
            };

            Assert.Equal(anyId, sut.Id);
        }

        [Fact]
        public void SetNameCorrectly()
        {
            const string anyName = "John Smith";
            var sut = new Client
            {
                Name = anyName
            };

            Assert.Equal(anyName, sut.Name);
        }

        [Theory]
        [InlineData(ClientStatus.Gold)]
        [InlineData(ClientStatus.Platinum)]
        [InlineData(ClientStatus.Titanium)]
        public void SetStatusCorrectly(ClientStatus anyStatus)
        {
            var sut = new Client
            {
                ClientStatus = anyStatus
            };

            Assert.Equal(anyStatus, sut.ClientStatus);
        }
    }
}