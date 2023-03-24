namespace LegacyApp
{
    public interface IUserService
    {
        bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId);
    }
}