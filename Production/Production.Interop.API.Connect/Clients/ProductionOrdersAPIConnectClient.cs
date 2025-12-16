namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ProductionOrdersAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProductionOrder, System.Guid, Common.Models.Input.ProductionOrderInputModel, Common.Models.Display.ProductionOrderDisplayModel, Common.Models.Filter.ProductionOrderFilterModel>
    {
        public ProductionOrdersAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/production/productionorders";
    }
}
