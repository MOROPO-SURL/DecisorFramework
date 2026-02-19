namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class OrganizationalStructuresAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.OrganizationalStructure, System.Guid, Common.Models.Input.OrganizationalStructureInputModel, Common.Models.Display.OrganizationalStructureDisplayModel, Common.Models.Filter.OrganizationalStructureFilterModel>
    {
        public OrganizationalStructuresAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationalstructures";
    }
}