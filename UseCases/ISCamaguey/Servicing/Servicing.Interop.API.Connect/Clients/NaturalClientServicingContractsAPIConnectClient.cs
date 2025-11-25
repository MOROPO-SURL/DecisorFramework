namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientServicingContractsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientServicingContract, System.Guid, Common.Models.Input.NaturalClientServicingContractInputModel, Common.Models.Display.NaturalClientServicingContractDisplayModel, Common.Models.Filter.NaturalClientServicingContractFilterModel>
    {
        public NaturalClientServicingContractsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclientservicingcontracts";
    }
}