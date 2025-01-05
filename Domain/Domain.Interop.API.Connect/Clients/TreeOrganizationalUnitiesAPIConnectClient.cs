namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class TreeOrganizationalUnitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.OrganizationalUnity, System.Guid, Common.Models.Display.OrganizationalUnityTreeDisplayModel>
    {
        public TreeOrganizationalUnitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/organizationalunities/tree";
    }
}
