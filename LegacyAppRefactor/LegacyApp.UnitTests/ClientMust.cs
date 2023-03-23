namespace LegacyApp.UnitTests;

public class ClientMust
{
    [Fact]
    public void SetIdCorrectly()
    {
        var anyId = 1;
        var sut = new Client
        {
            Id = anyId
        };

        Assert.Equal(anyId, sut.Id);
    }

    [Fact]
    public void SetNameCorrectly()
    {
        var anyName = "John";
        var sut = new Client
        {
            Name = anyName
        };

        Assert.Equal(anyName, sut.Name);
    }

    [Fact]
    public void SetStatusCorrectly()
    {
        var anyStatus = ClientStatus.Gold;
        var sut = new Client
        {
            ClientStatus = anyStatus
        };

        Assert.Equal(anyStatus, sut.ClientStatus);
    }
}