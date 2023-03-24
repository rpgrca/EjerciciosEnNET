namespace LegacyApp.UnitTests;

public class UserServiceMust
{
    private const int ANY_CLIENT_ID = 1;
    private const int ANY_CREDIT_ABOVE_MINIMUM = 37000;
    private const int CREDIT_LIMIT = 500;
    private const int ANY_CREDIT_BELOW_MINIMUM = 499;
    private const string ANY_FIRSTNAME = "John";
    private const string ANY_SURNAME = "Smith";
    private const string ANY_FULLNAME = $"{ANY_FIRSTNAME} {ANY_SURNAME}";
    private const string ANY_VERY_IMPORTANT_CLIENT = "VeryImportantClient";
    private const string ANY_VALID_EMAIL = "john@smith.com";
    private const string INVALID_MAIL_WITHOUT_DOT = "john@smithcom";
    private const string INVALID_MAIL_WITHOUT_AT = "johnsmith.com";
    private static readonly DateTime ANY_ADULT_DATE_OF_BIRTH = new(2000, 3, 12);
    private static readonly DateTime ANY_CHILD_DATE_OF_BIRTH = new(2018, 5, 16);
    private static readonly DateTime CURRENT_DATE_TIME = new(2023, 3, 24);

    [Fact]
    public void ReturnTrue_WhenAllChecksHavePassed()
    {
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(CreateClient(ANY_FULLNAME));
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_ABOVE_MINIMUM));

        var result = sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_WhenAllChecksHavePassed()
    {
        var clientStub = CreateClient(ANY_FULLNAME);
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(clientStub);
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_ABOVE_MINIMUM));

        var result = sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.Same(clientStub, userDataAccessSpy.AddedUser!.Client);
        Assert.Equal(ANY_CREDIT_ABOVE_MINIMUM, userDataAccessSpy.AddedUser.CreditLimit);
        Assert.Equal(ANY_FIRSTNAME, userDataAccessSpy.AddedUser.Firstname);
        Assert.Equal(ANY_SURNAME, userDataAccessSpy.AddedUser.Surname);
        Assert.Equal(ANY_ADULT_DATE_OF_BIRTH, userDataAccessSpy.AddedUser.DateOfBirth);
        Assert.Equal(ANY_VALID_EMAIL, userDataAccessSpy.AddedUser.EmailAddress);
        Assert.Equal(ANY_CLIENT_ID, userDataAccessSpy.AddedUser.Id);
        Assert.True(userDataAccessSpy.AddedUser.HasCreditLimit);
    }

    private static Client CreateClient(string name)
    {
        return new Client
        {
            Id = ANY_CLIENT_ID,
            Name = name,
            ClientStatus = ClientStatus.Titanium
        };
    }

    [Fact]
    public void ReturnFalse_WhenUserCreditIsLessThan500()
    {
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(CreateClient(ANY_FULLNAME));
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_BELOW_MINIMUM));

        var result = sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.False(result);
    }

    [Fact]
    public void DoNotAddUser_WhenUserCreditIsLessThan500()
    {
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(CreateClient(ANY_FULLNAME));
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_BELOW_MINIMUM));

        sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.Null(userDataAccessSpy.AddedUser);
    }

    [Fact]
    public void ReturnTrue_WhenUserHasNoCreditLimit()
    {
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(CreateClient(ANY_VERY_IMPORTANT_CLIENT));
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_ABOVE_MINIMUM));

        var result = sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.True(result);
    }

    [Fact]
    public void AddUser_WhenUserHasNoCreditLimit()
    {
        var clientStub = CreateClient(ANY_VERY_IMPORTANT_CLIENT);
        var clockStub = new ClockStub(CURRENT_DATE_TIME);
        var userDataAccessSpy = new UserDataAccessSpy();
        var clientRepositoryStub = new ClientRepositoryStub(clientStub);
        var sut = new UserService(userDataAccessSpy, clientRepositoryStub, clockStub, () => new UserCreditServiceCreatorStub(ANY_CREDIT_ABOVE_MINIMUM));

        var result = sut.AddUser(ANY_FIRSTNAME, ANY_SURNAME, ANY_VALID_EMAIL, ANY_ADULT_DATE_OF_BIRTH, ANY_CLIENT_ID);
        Assert.Same(clientStub, userDataAccessSpy.AddedUser!.Client);
        Assert.Equal(0, userDataAccessSpy.AddedUser.CreditLimit);
        Assert.Equal(ANY_FIRSTNAME, userDataAccessSpy.AddedUser.Firstname);
        Assert.Equal(ANY_SURNAME, userDataAccessSpy.AddedUser.Surname);
        Assert.Equal(ANY_ADULT_DATE_OF_BIRTH, userDataAccessSpy.AddedUser.DateOfBirth);
        Assert.Equal(ANY_VALID_EMAIL, userDataAccessSpy.AddedUser.EmailAddress);
        Assert.Equal(ANY_CLIENT_ID, userDataAccessSpy.AddedUser.Id);
        Assert.False(userDataAccessSpy.AddedUser.HasCreditLimit);
    }


}