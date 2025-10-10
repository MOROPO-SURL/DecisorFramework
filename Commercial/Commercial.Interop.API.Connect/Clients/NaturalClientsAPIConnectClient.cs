using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class NaturalClientsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.NaturalClient, System.Guid, NaturalClientInputModel, NaturalClientDisplayModel>
    {
        public NaturalClientsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/commercial/naturalclients";

        public System.Threading.Tasks.Task<NaturalClientDisplayModel> GetByContactAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<NaturalClientDisplayModel>($"{TargetController}/by/contact/{key}");
        }
    }
}
