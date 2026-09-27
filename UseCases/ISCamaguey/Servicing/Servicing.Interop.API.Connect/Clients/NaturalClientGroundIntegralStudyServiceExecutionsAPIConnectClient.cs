namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientGroundIntegralStudyServiceExecutionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientGroundIntegralStudyServiceExecution, System.Guid, Common.Models.Input.NaturalClientGroundIntegralStudyServiceExecutionInputModel, Common.Models.Display.NaturalClientGroundIntegralStudyServiceExecutionDisplayModel, Common.Models.Filter.NaturalClientGroundIntegralStudyServiceExecutionFilterModel>
    {
        public NaturalClientGroundIntegralStudyServiceExecutionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/naturalclientgroundintegralstudyserviceexecutions";
    }
}