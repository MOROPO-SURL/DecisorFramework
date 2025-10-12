using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class NaturalBusinessKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<NaturalBusinessKind, System.Guid, NaturalBusinessKindDisplayModel>
    {
        public NaturalBusinessKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/naturalbusinesskinds";
    }
}
