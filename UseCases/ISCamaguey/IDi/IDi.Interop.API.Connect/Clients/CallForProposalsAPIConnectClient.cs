namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class CallForProposalsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.CallForProposal, System.Guid, Common.Models.Input.CallForProposalInputModel, Common.Models.Display.CallForProposalDisplayModel, Common.Models.Filter.CallForProposalFilterModel>
    {
        public CallForProposalsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/callforproposals";
    }
}
