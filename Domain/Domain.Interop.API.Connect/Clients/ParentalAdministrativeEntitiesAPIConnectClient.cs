namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class ParentalAdministrativeEntitiesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.AdministrativeEntity, System.Guid, Common.Models.Input.AdministrativeEntityInputModel, Common.Models.Display.AdministrativeEntityParentalDisplayModel>
    {
        public ParentalAdministrativeEntitiesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/administrative_entities/parental";
    }
}
