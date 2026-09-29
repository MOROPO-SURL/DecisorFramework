namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ScientificTechnicalResultsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ScientificTechnicalResult, System.Guid, Common.Models.Input.ScientificTechnicalResultInputModel, Common.Models.Display.ScientificTechnicalResultDisplayModel, Common.Models.Filter.ScientificTechnicalResultFilterModel>
    {
        public ScientificTechnicalResultsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/scientifictechnicalresults";
    }
}