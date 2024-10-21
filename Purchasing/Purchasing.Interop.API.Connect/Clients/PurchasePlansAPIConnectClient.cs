using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Connect.Clients
{
    public class PurchasePlansAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.PurchasePlan, System.Guid, PurchasePlanInputModel, PurchasePlanDisplayModel, PurchasePlanFilterModel>
    {
        public PurchasePlansAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        public virtual async System.Threading.Tasks.Task ApproveAsync(System.Guid key)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync($"{TargetController}/approve/{key}");
        }

        protected override string TargetController => "api/purchaseplans";
    }
}
