
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients
{
    public class CubanStandardAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.CubanStandard, int, Common.Models.Input.CubanStandardInputModel, Common.Models.Display.CubanStandardDisplayModel, Common.Models.Filter.CubanStandardFilterModel>
    {
        public CubanStandardAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/usescase/quality/cubanstandard";
    }
}
