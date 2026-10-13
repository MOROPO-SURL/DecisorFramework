using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public sealed class NaturalClientVehicleLeasingControlActionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<NaturalClientVehicleLeasingControlAction, System.Guid, Common.Models.Input.NaturalClientVehicleLeasingControlActionInputModel, Common.Models.Display.NaturalClientVehicleLeasingControlActionDisplayModel, Common.Models.Filter.NaturalClientVehicleLeasingControlActionFilterModel>
    {
        public NaturalClientVehicleLeasingControlActionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/naturalclientvehicleleasingcontrolactions";
    }
}