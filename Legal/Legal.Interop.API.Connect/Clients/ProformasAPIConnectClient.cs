namespace MOROPO.Framework.Decisor.Legal.Interop.API.Connect.Clients
{
    public class ProformasAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Proforma, System.Guid, Common.Models.Input.ProformaInputModel, Common.Models.Display.ProformaDisplayModel>
    {
        public ProformasAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/legal/proformas";
    }
}
