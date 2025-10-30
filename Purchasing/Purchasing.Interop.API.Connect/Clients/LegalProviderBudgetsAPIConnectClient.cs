namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class LegalProviderBudgetsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.LegalProviderBudget, System.Guid, Common.Models.Input.LegalProviderBudgetInputModel, Common.Models.Display.LegalProviderBudgetDisplayModel>
    {
        public LegalProviderBudgetsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/purchasing/legalproviderbudgets";
    }
}
