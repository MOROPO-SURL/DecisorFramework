namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public sealed class AnalysisQualityChecksAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.AnalysisQualityCheck, System.Guid, Common.Models.Input.AnalysisQualityCheckInputModel, Common.Models.Display.AnalysisQualityCheckDisplayModel, Common.Models.Filter.AnalysisQualityCheckFilterModel>
    {
        public AnalysisQualityChecksAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/analysisqualitychecks";
    }
}