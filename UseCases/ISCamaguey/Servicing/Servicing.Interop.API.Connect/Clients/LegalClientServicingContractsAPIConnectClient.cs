namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientServicingContractsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientServicingContract, int, Common.Models.Input.LegalClientServicingContractInputModel, Common.Models.Display.LegalClientServicingContractDisplayModel, Common.Models.Filter.LegalClientServicingContractFilterModel>
    {
        public LegalClientServicingContractsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclientservicingcontracts";
    }
}
