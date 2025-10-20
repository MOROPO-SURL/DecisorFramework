namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Connect.Clients
{
    public class ParticipatingOrganizationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ParticipatingOrganization, System.Guid, Common.Models.Input.ParticipatingOrganizationInputModel, Common.Models.Display.ParticipatingOrganizationDisplayModel, Common.Models.Filter.ParticipatingOrganizationFilterModel>
    {
        public ParticipatingOrganizationsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/idi/participatingorganizations";
    }
}
