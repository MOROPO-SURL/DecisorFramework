namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientSampleAnalysisServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientSampleAnalysisServiceOrder, long, Common.Models.Input.NaturalClientSampleAnalysisServiceOrderInputModel, Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Common.Models.Filter.NaturalClientSampleAnalysisServiceOrderFilterModel>
    {
        public NaturalClientSampleAnalysisServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclientsampleanalysisserviceorders";
    }
}