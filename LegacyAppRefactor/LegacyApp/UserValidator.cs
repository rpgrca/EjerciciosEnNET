namespace LegacyApp
{
    public class UserValidator : IUserDataValidator
    {
        private readonly IClock _clock;

        public UserValidator(IClock clock) => _clock = clock;

        public bool Validate(string firname, string surname, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains('@') || !email.Contains('.'))
            {
                return false;
            }

            var now = _clock.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }
    }
}