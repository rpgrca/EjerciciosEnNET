namespace LegacyApp
{
    public class UserService : IUserService
    {
		private readonly IUserDataAccess _userDataAccess;
		private readonly IClientRepository _clientRepository;
		private readonly Func<IUserCreditService> _userCreditServiceCreator;
        private readonly IClock _clock;

        public UserService()
		{
			_userDataAccess = new UserDataAccess();
            _clientRepository = new ClientRepository();
            _clock = new StandardClock();
			_userCreditServiceCreator = () => new UserCreditServiceClient();
		}

		public UserService(IUserDataAccess userDataAccess, IClientRepository clientRepository, IClock clock, Func<IUserCreditService> userCreditServiceCreator)
		{
			_userDataAccess = userDataAccess;
			_clientRepository = clientRepository;
			_userCreditServiceCreator = userCreditServiceCreator;
            _clock = clock;
		}

        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
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

            var client = _clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                Id = clientId,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firname,
                Surname = surname
            };

            if (client.Name == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                user.HasCreditLimit = true;
                using var userCreditService = _userCreditServiceCreator();
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                // Do credit check
                user.HasCreditLimit = true;
                using var userCreditService = _userCreditServiceCreator();
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }
    }
}