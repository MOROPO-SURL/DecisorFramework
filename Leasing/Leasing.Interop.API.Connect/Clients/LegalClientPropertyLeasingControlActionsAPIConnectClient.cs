using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Connect.Clients
{
    public sealed class LegalClientPropertyLeasingControlActionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<LegalClientPropertyLeasingControlAction, System.Guid, Common.Models.Input.LegalClientPropertyLeasingControlActionInputModel, Common.Models.Display.LegalClientPropertyLeasingControlActionDisplayModel, Common.Models.Filter.LegalClientPropertyLeasingControlActionFilterModel>
    {
        public LegalClientPropertyLeasingControlActionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/leasing/legalclientpropertyleasingcontrolactions";
    }
}