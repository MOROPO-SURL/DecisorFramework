namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class NaturalClientVehicleLeasingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.NaturalClientVehicleLeasing, System.Guid, Common.Models.Input.NaturalClientVehicleLeasingInputModel, Common.Models.Display.NaturalClientVehicleLeasingDisplayModel>
    {
        public NaturalClientVehicleLeasingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/naturalclientvehicleleasings";
    }
}
