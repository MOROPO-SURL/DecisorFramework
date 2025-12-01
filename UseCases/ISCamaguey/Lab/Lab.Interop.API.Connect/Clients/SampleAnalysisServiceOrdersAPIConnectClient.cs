namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class SampleAnalysisServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long, Common.Models.Display.CommonSampleAnalysisServiceOrderDisplayModel>
    {
        public SampleAnalysisServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/sampleanalysisserviceorders";
    }
}