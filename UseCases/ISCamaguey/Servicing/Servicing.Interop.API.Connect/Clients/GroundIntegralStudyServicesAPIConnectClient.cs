namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class GroundIntegralStudyServicesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.GroundIntegralStudyService, System.Guid, Common.Models.Input.GroundIntegralStudyServiceInputModel, Common.Models.Display.GroundIntegralStudyServiceDisplayModel, Common.Models.Filter.GroundIntegralStudyServiceFilterModel>
    {
        public GroundIntegralStudyServicesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/servicing/groundintegralstudyservices";
    }
}
