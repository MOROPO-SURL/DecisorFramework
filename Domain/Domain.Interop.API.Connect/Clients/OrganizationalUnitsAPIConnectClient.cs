namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class OrganizationalUnitsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.OrganizationalUnit, System.Guid, Common.Models.Input.OrganizationalUnitInputModel, Common.Models.Display.OrganizationalUnitDisplayModel, Common.Models.Filter.OrganizationalUnitFilterModel>
    {
        public OrganizationalUnitsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationalunits";
    }
}
