namespace LegacyApp
{
    [System.ServiceModel.ServiceContract(ConfigurationName = "LegacyApp.IUserCreditService")]
    public interface IUserCreditService : IDisposable
    {
        [System.ServiceModel.OperationContract(Action = "http://totally-real-service.com/IUserCreditService/GetCreditLimit", ReplyAction = "http://totally-real-service.com/IUserCreditService/GetCreditLimitResponse")]
        int GetCreditLimit(string firstname, string surname, System.DateTime dateOfBirth);
    }

    public interface IUserCreditServiceChannel : IUserCreditService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThrough()]
    public partial class UserCreditServiceClient : System.ServiceModel.ClientBase<IUserCreditService>, IUserCreditService
    {
        public UserCreditServiceClient()
        {
        }

		public UserCreditServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress):
			base(binding, remoteAddress)
		{
		}

		public int GetCreditLimit(string firstname, string surname, System.DateTime dateOfBirth)
		{
			return base.Channel.GetCreditLimit(firstname, surname, dateOfBirth);
		}
	}
}
