namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public class LegalClientVehicleLeasingsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.LegalClientVehicleLeasing, System.Guid, Common.Models.Input.LegalClientVehicleLeasingInputModel, Common.Models.Display.LegalClientVehicleLeasingDisplayModel>
    {
        public LegalClientVehicleLeasingsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/leasing/legalclientvehicleleasings";
    }
}