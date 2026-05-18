namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class ActionsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Action, System.Guid, Common.Models.Input.ActionInputModel, Common.Models.Display.ActionDisplayModel>
    {
        public ActionsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/actions";
    }
}