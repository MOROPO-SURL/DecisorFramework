using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class PurchaseZonesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.PurchaseZone, System.Guid, PurchaseZoneInputModel, PurchaseZoneDisplayModel>
    {
        public PurchaseZonesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/purchasezones";
    }
}
