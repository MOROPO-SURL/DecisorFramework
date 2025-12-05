namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class NaturalProviderBudgetsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.NaturalProviderBudget, System.Guid, Common.Models.Input.NaturalProviderBudgetInputModel, Common.Models.Display.NaturalProviderBudgetDisplayModel, Common.Models.Filter.NaturalProviderBudgetFilterModel>
    {
        public NaturalProviderBudgetsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/purchasing/naturalproviderbudgets";
    }
}
