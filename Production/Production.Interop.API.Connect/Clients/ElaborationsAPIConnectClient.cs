namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ElaborationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Elaboration, System.Guid, Common.Models.Input.ElaborationInputModel, Common.Models.Display.ElaborationDisplayModel>
    {
        public ElaborationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/production/elaborations";
    }
}
