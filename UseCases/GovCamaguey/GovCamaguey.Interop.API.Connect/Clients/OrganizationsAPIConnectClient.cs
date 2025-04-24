namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class OrganizationsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.Organization, System.Guid, Common.Models.Input.OrganizationInputModel, Common.Models.Display.OrganizationDisplayModel>
    {
        public OrganizationsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/organizations";
    }
}
