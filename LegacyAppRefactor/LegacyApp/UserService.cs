namespace LegacyApp;

public class UserService : IUserService
{
    private readonly IUserDataAccess _userDataAccess;
    private readonly IClientRepository _clientRepository;
    private readonly IUserDataValidator _userValidator;
    private readonly Func<IUserCreditService> _userCreditServiceCreator;

    public UserService()
    {
        _userDataAccess = new UserDataAccess();
        _clientRepository = new ClientRepository();
        _userCreditServiceCreator = () => new UserCreditServiceClient();
        _userValidator = new UserDataValidator(new StandardClock());
    }

    public UserService(IUserDataAccess userDataAccess, IClientRepository clientRepository, IUserDataValidator userValidator, Func<IUserCreditService> userCreditServiceCreator)
    {
        _userDataAccess = userDataAccess;
        _clientRepository = clientRepository;
        _userCreditServiceCreator = userCreditServiceCreator;
        _userValidator = userValidator;
    }

    public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
    {
        var user = new User
        {
            Id = clientId,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            Firstname = firname,
            Surname = surname
        };

        if (! _userValidator.Validate(user))
        {
            return false;
        }

        var client = _clientRepository.GetById(clientId);
        user.Client = client;

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