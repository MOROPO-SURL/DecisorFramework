namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients
{
    public class ProductsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Product, System.Guid, Common.Models.Input.ProductInputModel, Common.Models.Display.ProductDisplayModel>
    {
        public ProductsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/products";
    }
}
