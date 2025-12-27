namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ProjectProposalsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProjectProposal, System.Guid, Common.Models.Input.ProjectProposalInputModel, Common.Models.Display.ProjectProposalDisplayModel, Common.Models.Filter.ProjectProposalFilterModel>
    {
        public ProjectProposalsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/projectproposals";
    }
}