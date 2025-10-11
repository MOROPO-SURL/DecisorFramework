namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class ParentalOrganizationalUnitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.OrganizationalUnity, System.Guid, Common.Models.Input.OrganizationalUnityInputModel, Common.Models.Display.OrganizationalUnityParentalDisplayModel>
    {
        public ParentalOrganizationalUnitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/organizationalunities/parental";
    }
}
