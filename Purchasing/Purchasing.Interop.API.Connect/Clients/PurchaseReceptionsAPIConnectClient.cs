using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class PurchaseReceptionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityManagementAPIConnectClient<Persistence.Entities.PurchaseReception, System.Guid, PurchaseReceptionInputModel, PurchaseReceptionDisplayModel>
    {
        public PurchaseReceptionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/purchasereceptions";
    }
}
