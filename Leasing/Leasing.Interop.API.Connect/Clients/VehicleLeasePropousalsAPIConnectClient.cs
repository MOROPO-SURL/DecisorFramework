namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class VehicleLeasePropousalsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.VehicleLeasePropousal, System.Guid, Common.Models.Input.VehicleLeasePropousalInputModel, Common.Models.Display.VehicleLeasePropousalDisplayModel>
    {
        public VehicleLeasePropousalsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/vehicleleasepropousals";
    }
}
