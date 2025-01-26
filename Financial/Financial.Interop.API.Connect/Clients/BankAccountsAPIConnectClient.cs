namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class BankAccountsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.BankAccount, System.Guid, Common.Models.Input.BankAccountInputModel, Common.Models.Display.BankAccountDisplayModel, Common.Models.Filter.BankAccountFilterModel>
    {
        public BankAccountsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/financial/bankaccounts";
    }
}
