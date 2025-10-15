namespace MOROPO.Framework.Decisor.Governance.Interop.API.Connect.Clients
{
    public class DecisionMakingGroupsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.DecisionMakingGroup, System.Guid, Common.Models.Input.DecisionMakingGroupInputModel, Common.Models.Display.DecisionMakingGroupDisplayModel>
    {
        public DecisionMakingGroupsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/governance/decisionmakinggroups";
    }
}
