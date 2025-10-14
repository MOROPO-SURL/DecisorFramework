using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class LegalClientsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.LegalClient, System.Guid, LegalClientInputModel, LegalClientDisplayModel>
    {
        public LegalClientsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/commercial/legalclients";

        public System.Threading.Tasks.Task<LegalClientDisplayModel> GetByContactAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<LegalClientDisplayModel>($"{TargetController}/by/contact/{key}");
        }
    }
}
