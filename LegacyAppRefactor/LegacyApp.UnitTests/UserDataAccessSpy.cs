using LegacyApp;

public class UserDataAccessSpy : IUserDataAccess
{
    public User? AddedUser { get; private set; }

    public void AddUser(User user) => AddedUser = user;
}