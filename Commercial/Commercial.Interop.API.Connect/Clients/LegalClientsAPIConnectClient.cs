namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Connect.Clients
{
    public class LegalClientsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.LegalClient, System.Guid, Common.Models.Input.LegalClientInputModel, Common.Models.Display.LegalClientDisplayModel, Common.Models.Filter.LegalClientFilterModel>
    {
        public LegalClientsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/commercial/legalclients";

        public System.Threading.Tasks.Task<Common.Models.Display.LegalClientDisplayModel> GetByContactAsync(System.Guid key)
        {
            return httpClientHelperProvider.HttpClientHelper.GetAsync<Common.Models.Display.LegalClientDisplayModel>($"{TargetController}/by/contact/{key}");
        }
    }
}
