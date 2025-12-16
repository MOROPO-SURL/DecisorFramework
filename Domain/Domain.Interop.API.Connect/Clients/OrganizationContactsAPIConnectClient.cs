namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class OrganizationContactsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.OrganizationContact, System.Guid, Common.Models.Input.OrganizationContactInputModel, Common.Models.Display.OrganizationContactDisplayModel, Common.Models.Filter.OrganizationContactFilterModel>
    {
        public OrganizationContactsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationcontacts";
    }
}