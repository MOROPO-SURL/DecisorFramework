namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class AdministrativeEntityKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.AdministrativeEntityKind, System.Guid, Common.Models.Display.AdministrativeEntityKindDisplayModel>
    {
        public AdministrativeEntityKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/administrativeentitykinds";
    }
}
