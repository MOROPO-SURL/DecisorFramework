namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class VehiclesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Vehicle, System.Guid, Common.Models.Input.VehicleInputModel, Common.Models.Display.VehicleDisplayModel, Common.Models.Filter.VehicleFilterModel>
    {
        public VehiclesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/vehicles";
    }
}
