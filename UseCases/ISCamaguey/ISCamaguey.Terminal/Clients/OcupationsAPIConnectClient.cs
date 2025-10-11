using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Interop.API.Common.Models.Input;

namespace MOROPO.ISCamaguey.Decisor.Terminal.Clients
{
    public class OcupationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<Ocupation, System.Guid, OcupationInputModel, OcupationDisplayModel>
    {
        public OcupationsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/hhrr/ocupations";
    }
}
