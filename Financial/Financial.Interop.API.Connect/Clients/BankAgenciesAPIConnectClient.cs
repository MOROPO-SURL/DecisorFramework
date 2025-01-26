namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class BankAgenciesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.BankAgency, System.Guid, Common.Models.Input.BankAgencyInputModel, Common.Models.Display.BankAgencyDisplayModel>
    {
        public BankAgenciesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/financial/bankagencies";
    }
}
