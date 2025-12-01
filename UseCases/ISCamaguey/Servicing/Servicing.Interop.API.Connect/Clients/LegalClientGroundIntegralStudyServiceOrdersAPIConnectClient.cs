
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientGroundIntegralStudyServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder, long, Common.Models.Input.LegalClientGroundIntegralStudyServiceOrderInputModel, Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Common.Models.Filter.LegalClientGroundIntegralStudyServiceOrderFilterModel>
    {
        public LegalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }
        protected override string TargetController => "api/servicing/legalclientgroundintegralstudyserviceorders";
    }
}
