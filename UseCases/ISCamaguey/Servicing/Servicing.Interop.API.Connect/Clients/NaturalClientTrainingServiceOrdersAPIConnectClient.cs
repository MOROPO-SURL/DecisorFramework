
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Connect.Clients
{
    public class NaturalClientTrainingServiceOrdersAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClientTrainingServiceOrder, long, Common.Models.Input.NaturalClientTrainingServiceOrderInputModel, Common.Models.Display.NaturalClientTrainingServiceOrderDisplayModel, Common.Models.Filter.NaturalClientTrainingServiceOrderFilterModel>
    {
        public NaturalClientTrainingServiceOrdersAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }
        protected override string TargetController => "api/servicing/naturalclienttrainingserviceorders";
    }
}
