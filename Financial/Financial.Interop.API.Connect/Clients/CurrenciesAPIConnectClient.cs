namespace MOROPO.Framework.Decisor.Financial.Interop.API.Connect.Clients
{
    public class CurrenciesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Currency, System.Guid, Common.Models.Input.CurrencyInputModel, Common.Models.Display.CurrencyDisplayModel, Common.Models.Filter.CurrencyFilterModel>
    {
        public CurrenciesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/financial/currencies";
    }
}
