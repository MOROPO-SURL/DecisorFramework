
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class LegalClientTrainingServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClientTrainingServiceOrder, long, Common.Models.Input.LegalClientTrainingServiceOrderInputModel, Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel, Common.Models.Filter.LegalClientTrainingServiceOrderFilterModel>
    {
        public LegalClientTrainingServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }
        protected override string TargetController => "api/servicing/legalclienttrainingserviceorders";
    }
}
