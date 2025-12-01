
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientGroundIntegralStudyServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder, long, Common.Models.Input.NaturalClientGroundIntegralStudyServiceOrderInputModel, Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Common.Models.Filter.NaturalClientGroundIntegralStudyServiceOrderFilterModel>
    {
        public NaturalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }
        protected override string TargetController => "api/servicing/naturalclientgroundintegralstudyserviceorders";
    }
}
