namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientGroundIntegralStudyServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientGroundIntegralStudyServiceExecution, System.Guid, Common.Models.Input.LegalClientGroundIntegralStudyServiceExecutionInputModel, Common.Models.Display.LegalClientGroundIntegralStudyServiceExecutionDisplayModel, Common.Models.Filter.LegalClientGroundIntegralStudyServiceExecutionFilterModel>
    {
        public LegalClientGroundIntegralStudyServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/legalclientgroundintegralstudyserviceexecutions";
    }
}