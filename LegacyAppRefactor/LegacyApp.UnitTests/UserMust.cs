namespace LegacyApp.UnitTests;

public class UserMust
{
    [Fact]
    public void SetFirstNameCorrectly()
    {
        const string anyFirstname = "John";
        var sut = new User
        {
            Firstname = anyFirstname
        };

        Assert.Equal(anyFirstname, sut.Firstname);
    }

    [Fact]
    public void SetSurnameCorrectly()
    {
        const string anySurname = "Smith";
        var sut = new User
        {
            Surname = anySurname
        };

        Assert.Equal(anySurname, sut.Surname);
    }

    [Fact]
    public void SetDateOfBirthCorrectly()
    {
        DateTime anyDateOfBirth = new DateTime(2000, 3, 12);
        var sut = new User
        {
            DateOfBirth = anyDateOfBirth
        };

        Assert.Equal(anyDateOfBirth, sut.DateOfBirth);
    }

    [Fact]
    public void SetEmailAddressCorrectly()
    {
        const string anyEmail = "john@smith.com";
        var sut = new User
        {
            EmailAddress = anyEmail
        };

        Assert.Equal(anyEmail, sut.EmailAddress);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void SetHasCreditLimitCorrectly(bool anyFlag)
    {
        var sut = new User
        {
            HasCreditLimit = anyFlag
        };

        Assert.Equal(anyFlag, sut.HasCreditLimit);
    }

    [Fact]
    public void SetCreditLimitCorrectly()
    {
        const int anyCreditLimit = 25000;
        var sut = new User
        {
            CreditLimit = anyCreditLimit
        };

        Assert.Equal(anyCreditLimit, sut.CreditLimit);
    }

    [Fact]
    public void SetClientCorrectly()
    {
        const int anyId = 1;
        const string anyName = "John Smith";
        const ClientStatus anyStatus = ClientStatus.Platinum;

        var anyClient = new Client
        {
            Id = anyId,
            Name = anyName,
            ClientStatus = anyStatus
        };

        var sut = new User
        {
            Client = anyClient
        };

        Assert.Same(anyClient, sut.Client);
    }
}

public class UserServiceMust
{
    [Fact]
    public void AddUserCorrectly_WhenAllChecksHavePassed()
    {
        const int anyCredit = 37000;
        const int anyClientId = 1;
        const string anyFirstname = "John";
        const string anySurname = "Smith";
        const string anyEmail = "john@smith.com";
        var anyDateOfBirth = new DateTime(2000, 3, 12);

        var clientStub = new Client
        {
            Id = anyClientId,
            Name = "John Smith",
            ClientStatus = ClientStatus.Titanium
        };

        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(clientStub);
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, () => new UserCreditServiceCreatorStub(anyCredit));
        var result = sut.AddUser(anyFirstname, anySurname, anyEmail, anyDateOfBirth, anyClientId);

        Assert.True(result);
    }
}