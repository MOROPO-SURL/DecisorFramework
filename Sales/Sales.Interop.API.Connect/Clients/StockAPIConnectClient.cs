using MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models;

namespace MOROPO.Framework.Decisor.Sales.Interop.API.Connect.Clients
{
    public class StockAPIConnectClient
    {
        protected readonly Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;

        public StockAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            this.httpClientHelperProvider = httpClientHelperProvider;
        }

        public virtual async System.Threading.Tasks.Task<StockOverviewModel[]> GetOverviewsAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<StockOverviewModel[]>("api/stock/overviews");
        }

        public virtual async System.Threading.Tasks.Task<StockDetailsModel> GetDetailsAsync(System.Guid productId)
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<StockDetailsModel>($"api/stock/details/{productId}");
        }
    }
}
