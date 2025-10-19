namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class SampleAnalysisServicesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.SampleAnalysisService, System.Guid, Common.Models.Input.SampleAnalysisServiceInputModel, Common.Models.Display.SampleAnalysisServiceDisplayModel, Common.Models.Filter.SampleAnalysisServiceFilterModel>
    {
        public SampleAnalysisServicesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/sampleanalysisservices";
    }
}
