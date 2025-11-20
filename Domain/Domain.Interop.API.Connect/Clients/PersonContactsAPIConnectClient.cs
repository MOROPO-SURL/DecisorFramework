namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class PersonContactsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.PersonContact, System.Guid, Common.Models.Input.PersonContactInputModel, Common.Models.Display.PersonContactDisplayModel, Common.Models.Filter.PersonContactFilterModel>
    {
        public PersonContactsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/personcontacts";
    }
}