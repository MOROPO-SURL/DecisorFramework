
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients
{
    public class IsoStandardAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.IsoStandard, int, Common.Models.Input.IsoStandardInputModel, Common.Models.Display.IsoStandardDisplayModel, Common.Models.Filter.IsoStandardFilterModel>
    {
        public IsoStandardAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/usescase/quality/isostandard";
    }
}
