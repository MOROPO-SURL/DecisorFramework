namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class VehicleEngineKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.VehicleEngineKind, System.Guid, Common.Models.Display.VehicleEngineKindDisplayModel>
    {
        public VehicleEngineKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/vehicleenginekinds";
    }
}
