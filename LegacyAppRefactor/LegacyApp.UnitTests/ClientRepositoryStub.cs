namespace LegacyApp.UnitTests;

public class ClientRepositoryStub : IClientRepository
{
    private readonly Client _clientToReturn;

    public ClientRepositoryStub(Client clientToReturn) =>
        _clientToReturn = clientToReturn;

    public Client GetById(int id) => _clientToReturn;
}
