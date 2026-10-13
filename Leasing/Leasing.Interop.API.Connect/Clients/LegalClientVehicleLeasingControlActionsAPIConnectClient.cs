using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public sealed class LegalClientVehicleLeasingControlActionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<LegalClientVehicleLeasingControlAction, System.Guid, Common.Models.Input.LegalClientVehicleLeasingControlActionInputModel, Common.Models.Display.LegalClientVehicleLeasingControlActionDisplayModel, Common.Models.Filter.LegalClientVehicleLeasingControlActionFilterModel>
    {
        public LegalClientVehicleLeasingControlActionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/legalclientvehicleleasingcontrolactions";
    }
}