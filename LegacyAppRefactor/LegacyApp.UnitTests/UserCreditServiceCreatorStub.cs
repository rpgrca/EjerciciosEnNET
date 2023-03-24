namespace LegacyApp.UnitTests;

public class UserCreditServiceCreatorStub : IUserCreditService
{
    private readonly int _creditLimit;

    public UserCreditServiceCreatorStub(int creditLimit) => _creditLimit = creditLimit;

    public void Dispose()
    {
    }

    public int GetCreditLimit(string firstname, string surname, DateTime dateOfBirth) => _creditLimit;
}