namespace LegacyApp
{
    public interface IUserDataValidator
    {
        bool Validate(string firname, string surname, string email, DateTime dateOfBirth);
    }
}