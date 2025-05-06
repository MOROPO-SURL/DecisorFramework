namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class VehicleKindsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEnableableEntityConsultAPIConnectClient<Persistence.Entities.VehicleKind, System.Guid, Common.Models.Display.VehicleKindDisplayModel>
    {
        public VehicleKindsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/vehiclekinds";
    }
}
