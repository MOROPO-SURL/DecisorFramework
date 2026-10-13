using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public sealed class NaturalClientPropertyLeasingControlActionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<NaturalClientPropertyLeasingControlAction, System.Guid, Common.Models.Input.NaturalClientPropertyLeasingControlActionInputModel, Common.Models.Display.NaturalClientPropertyLeasingControlActionDisplayModel, Common.Models.Filter.NaturalClientPropertyLeasingControlActionFilterModel>
    {
        public NaturalClientPropertyLeasingControlActionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/naturalclientpropertyleasingcontrolactions";
    }
}