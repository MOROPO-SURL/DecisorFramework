namespace MOROPO.Framework.Decisor.Legal.Interop.API.Connect.Clients
{
    public class CentralStateStructuresAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.CentralStateStructure, System.Guid, Common.Models.Input.CentralStateStructureInputModel, Common.Models.Display.CentralStateStructureDisplayModel>
    {
        public CentralStateStructuresAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/legal/centralstatestructures";
    }
}