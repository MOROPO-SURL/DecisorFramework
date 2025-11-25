namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientSampleAnalysisServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, long, Common.Models.Input.LegalClientSampleAnalysisServiceOrderInputModel, Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Common.Models.Filter.LegalClientSampleAnalysisServiceOrderFilterModel>
    {
        public LegalClientSampleAnalysisServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclientsampleanalysisserviceorders";
    }
}
