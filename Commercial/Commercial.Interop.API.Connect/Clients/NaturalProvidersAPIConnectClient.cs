using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class NaturalProvidersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.NaturalProvider, System.Guid, NaturalProviderInputModel, NaturalProviderDisplayModel>
    {
        public NaturalProvidersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/naturalproviders";

        public async System.Threading.Tasks.Task<long> CountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TargetController}/count");
        }
    }
}