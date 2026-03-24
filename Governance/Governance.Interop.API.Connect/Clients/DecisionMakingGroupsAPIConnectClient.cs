namespace MOROPO.Framework.Decisor.Governance.Interop.API.Connect.Clients
{
    public class DecisionMakingGroupsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.DecisionMakingGroup, System.Guid, Common.Models.Input.DecisionMakingGroupInputModel, Common.Models.Display.DecisionMakingGroupDisplayModel, Common.Models.Filter.DecisionMakingGroupFilterModel>
    {
        public DecisionMakingGroupsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/governance/decisionmakinggroups";
    }
}