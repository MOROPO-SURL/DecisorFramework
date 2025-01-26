namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ProductionPlansAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProductionPlan, System.Guid, Common.Models.Input.ProductionPlanInputModel, Common.Models.Display.ProductionPlanDisplayModel, Common.Models.Filter.ProductionPlanFilterModel>
    {
        public ProductionPlansAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        public virtual async System.Threading.Tasks.Task ApproveAsync(System.Guid key)
        {
            await httpClientHelperProvider.HttpClientHelper.PutAsync($"{TargetController}/approve/{key}");
        }

        protected override string TargetController => "api/production/productionplans";
    }
}
