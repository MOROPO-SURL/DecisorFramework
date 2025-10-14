using MOROPO.Framework.Decisor.Supervision.Interop.API.Common.Models;

namespace MOROPO.Framework.Decisor.Supervision.Interop.API.Connect.Clients
{
    public class InventoryAPIConnectClient
    {
        protected readonly Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider;

        public InventoryAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider)
        {
            this.httpClientHelperProvider = httpClientHelperProvider;
        }

        public virtual async System.Threading.Tasks.Task<InventoryStockOverviewModel[]> GetOverviewsAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<InventoryStockOverviewModel[]>("api/fwrk/supervision/inventory/overviews");
        }

        public virtual async System.Threading.Tasks.Task<InventoryStockDetailsModel> GetDetailsAsync(System.Guid productId)
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<InventoryStockDetailsModel>($"api/fwrk/supervision/inventory/details/{productId}");
        }
    }
}
