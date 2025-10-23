namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ExternalResearchersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ExternalResearcher, System.Guid, Common.Models.Input.ExternalResearcherInputModel, Common.Models.Display.ExternalResearcherDisplayModel, Common.Models.Filter.ExternalResearcherFilterModel>
    {
        public ExternalResearchersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/externalresearchers";
    }
}
