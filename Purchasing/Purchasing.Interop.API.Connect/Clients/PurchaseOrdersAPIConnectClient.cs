namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class PurchaseOrdersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.PurchaseOrder, System.Guid, Common.Models.Input.PurchaseOrderInputModel, Common.Models.Display.PurchaseOrderDisplayModel>
    {
        public PurchaseOrdersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/purchasing/purchaseorders";
    }
}
