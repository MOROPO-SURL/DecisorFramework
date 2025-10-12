namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Connect.Clients
{
    public class OcupationsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementFilteredAPIConnectClient<Persistence.Entities.Ocupation, System.Guid, Common.Models.Input.OcupationInputModel, Common.Models.Display.OcupationDisplayModel, Common.Models.Filter.OcupationFilterModel>
    {
        public OcupationsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/hhrr/ocupations";
    }
}
