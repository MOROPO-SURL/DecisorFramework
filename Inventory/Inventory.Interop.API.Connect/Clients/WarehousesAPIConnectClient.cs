namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
    public class WarehousesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Warehouse, System.Guid, Common.Models.Input.WarehouseInputModel, Common.Models.Display.WarehouseDisplayModel>
    {
        public WarehousesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/inventory/warehouses";

        public async System.Threading.Tasks.Task<long> CountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TargetController}/count");
        }
    }
}
