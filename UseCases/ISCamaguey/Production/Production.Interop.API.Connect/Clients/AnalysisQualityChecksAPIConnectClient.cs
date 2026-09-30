namespace MOROPO.ISCamaguey.Decisor.Production.Interop.API.Connect.Clients
{
    public sealed class ProductionQualityChecksAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProductionQualityCheck, System.Guid, Common.Models.Input.ProductionQualityCheckInputModel, Common.Models.Display.ProductionQualityCheckDisplayModel, Common.Models.Filter.ProductionQualityCheckFilterModel>
    {
        public ProductionQualityChecksAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/production/productionqualitychecks";
    }
}