namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class TreeAdministrativeEntitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.AdministrativeEntity, System.Guid, Common.Models.Display.AdministrativeEntityTreeDisplayModel>
    {
        public TreeAdministrativeEntitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/administrative_entities/tree";
    }
}
