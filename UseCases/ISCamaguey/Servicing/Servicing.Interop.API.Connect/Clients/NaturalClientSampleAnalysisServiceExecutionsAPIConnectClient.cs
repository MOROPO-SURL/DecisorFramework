namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientSampleAnalysisServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientSampleAnalysisServiceExecution, System.Guid, Common.Models.Input.NaturalClientSampleAnalysisServiceExecutionInputModel, Common.Models.Display.NaturalClientSampleAnalysisServiceExecutionDisplayModel, Common.Models.Filter.NaturalClientSampleAnalysisServiceExecutionFilterModel>
    {
        public NaturalClientSampleAnalysisServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclientsampleanalysisserviceexecutions";
    }
}