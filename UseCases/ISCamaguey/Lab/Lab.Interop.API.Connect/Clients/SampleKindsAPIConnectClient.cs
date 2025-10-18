using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class SampleKindsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<SampleKind, System.Guid, SampleKindDisplayModel, SampleKindFilterModel>
    {
        public SampleKindsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/samplekinds";
    }
}
