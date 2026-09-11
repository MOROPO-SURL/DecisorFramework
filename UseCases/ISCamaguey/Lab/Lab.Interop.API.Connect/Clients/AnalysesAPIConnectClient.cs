namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public sealed class AnalysesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Analysis, System.Guid, Common.Models.Input.AnalysisInputModel, Common.Models.Display.AnalysisDisplayModel, Common.Models.Filter.AnalysisFilterModel>
    {
        public AnalysesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/analyses";
    }
}