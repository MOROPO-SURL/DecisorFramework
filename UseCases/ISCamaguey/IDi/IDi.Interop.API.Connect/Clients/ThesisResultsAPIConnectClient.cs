namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ThesisResultsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ThesisResult, System.Guid, Common.Models.Input.ThesisResultInputModel, Common.Models.Display.ThesisResultDisplayModel, Common.Models.Filter.ThesisResultFilterModel>
    {
        public ThesisResultsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/thesisresults";
    }
}