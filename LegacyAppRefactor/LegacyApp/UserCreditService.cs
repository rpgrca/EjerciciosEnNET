namespace LegacyApp
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "LegacyApp.IUserCreditService")]
    public interface IUserCreditService : IDisposable
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://totally-real-service.com/IUserCreditService/GetCreditLimit", ReplyAction = "http://totally-real-service.com/IUserCreditService/GetCreditLimitResponse")]
        int GetCreditLimit(string firstname, string surname, System.DateTime dateOfBirth);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserCreditServiceChannel : IUserCreditService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserCreditServiceClient : System.ServiceModel.ClientBase<IUserCreditService>, IUserCreditService
    {
        public UserCreditServiceClient()
        {
        }

		public UserCreditServiceClient(string endpointConfigurationName):
            base(endpointConfigurationName)
        {
        }

        public UserCreditServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress):
			base(endpointConfigurationName, remoteAddress)
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
