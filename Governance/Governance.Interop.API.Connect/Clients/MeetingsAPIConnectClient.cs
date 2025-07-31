namespace MOROPO.Framework.Decisor.Governance.Interop.API.Connect.Clients
{
    public class MeetingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<Persistence.Entities.Meeting, System.Guid, Common.Models.Input.MeetingInputModel, Common.Models.Display.MeetingDisplayModel>
    {
        public MeetingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/meetings";
    }
}
