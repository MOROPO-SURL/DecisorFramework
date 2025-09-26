namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class LegalClientPropertyLeasingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.LegalClientPropertyLeasing, System.Guid, Common.Models.Input.LegalClientPropertyLeasingInputModel, Common.Models.Display.LegalClientPropertyLeasingDisplayModel>
    {
        public LegalClientPropertyLeasingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/legalclientpropertyleasings";
    }
}
