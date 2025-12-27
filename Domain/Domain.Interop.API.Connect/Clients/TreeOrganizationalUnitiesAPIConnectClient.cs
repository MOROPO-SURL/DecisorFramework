namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class TreeOrganizationalUnitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultFilteredAPIConnectClient<Persistence.Entities.OrganizationalUnity, System.Guid, Common.Models.Display.OrganizationalUnityTreeDisplayModel, Common.Models.Filter.OrganizationalUnityFilterModel>
    {
        public TreeOrganizationalUnitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationalunities/tree";
    }
}