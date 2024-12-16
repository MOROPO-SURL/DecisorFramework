using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class LegalProvidersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.LegalProvider, System.Guid, LegalProviderInputModel, LegalProviderDisplayModel>
    {
        public LegalProvidersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/legalproviders";

        public async System.Threading.Tasks.Task<long> CountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TargetController}/count");
        }
    }
}
