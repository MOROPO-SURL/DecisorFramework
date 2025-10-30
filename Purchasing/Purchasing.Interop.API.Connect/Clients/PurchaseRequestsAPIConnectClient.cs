namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class PurchaseRequestsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.PurchaseRequest, System.Guid, Common.Models.Input.PurchaseRequestInputModel, Common.Models.Display.PurchaseRequestDisplayModel>
    {
        public PurchaseRequestsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/purchasing/purchaserequests";
    }
}
