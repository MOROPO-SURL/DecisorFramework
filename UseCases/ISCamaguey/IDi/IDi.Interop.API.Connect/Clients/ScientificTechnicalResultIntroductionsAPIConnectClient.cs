namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ScientificTechnicalResultIntroductionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ScientificTechnicalResultIntroduction, System.Guid, Common.Models.Input.ScientificTechnicalResultIntroductionInputModel, Common.Models.Display.ScientificTechnicalResultIntroductionDisplayModel, Common.Models.Filter.ScientificTechnicalResultIntroductionFilterModel>
    {
        public ScientificTechnicalResultIntroductionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/scientifictechnicalresultintroductions";
    }
}