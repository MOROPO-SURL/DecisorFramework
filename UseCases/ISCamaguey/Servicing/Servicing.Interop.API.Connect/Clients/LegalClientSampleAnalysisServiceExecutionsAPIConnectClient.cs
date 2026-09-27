namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientSampleAnalysisServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientSampleAnalysisServiceExecution, System.Guid, Common.Models.Input.LegalClientSampleAnalysisServiceExecutionInputModel, Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel, Common.Models.Filter.LegalClientSampleAnalysisServiceExecutionFilterModel>
    {
        public LegalClientSampleAnalysisServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclientsampleanalysisserviceexecutions";
    }
}