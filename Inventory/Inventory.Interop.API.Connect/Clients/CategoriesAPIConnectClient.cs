namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
	public class CategoriesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Category, int, Common.Models.Input.CategoryInputModel, Common.Models.Display.CategoryDisplayModel>
    {
        public CategoriesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/inventory/categories";

        public async System.Threading.Tasks.Task<long> CountAsync()
        {
            return await httpClientHelperProvider.HttpClientHelper.GetAsync<long>($"{TargetController}/count");
        }
    }
}