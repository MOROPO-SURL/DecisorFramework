namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class NaturalClientsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalClient, System.Guid, Common.Models.Input.NaturalClientInputModel, Common.Models.Display.NaturalClientDisplayModel, Common.Models.Filter.NaturalClientFilterModel>
    {
        public NaturalClientsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/commercial/naturalclients";

        public System.Threading.Tasks.Task<Common.Models.Display.NaturalClientDisplayModel> GetByContactAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.Display.NaturalClientDisplayModel>($"{TargetController}/by/contact/{key}");
        }
    }
}
