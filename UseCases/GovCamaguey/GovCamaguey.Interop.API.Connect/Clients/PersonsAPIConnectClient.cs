namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Connect.Clients
{
    public class PersonsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.Person, System.Guid, Common.Models.Input.PersonInputModel, Common.Models.Display.PersonDisplayModel>
    {
        public PersonsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/governance/persons";
    }
}
