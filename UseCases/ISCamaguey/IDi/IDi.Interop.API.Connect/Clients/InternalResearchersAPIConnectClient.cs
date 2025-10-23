namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class InternalResearchersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.InternalResearcher, System.Guid, Common.Models.Input.InternalResearcherInputModel, Common.Models.Display.InternalResearcherDisplayModel, Common.Models.Filter.InternalResearcherFilterModel>
    {
        public InternalResearchersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/internalresearchers";
    }
}
