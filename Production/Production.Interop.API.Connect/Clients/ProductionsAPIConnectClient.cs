namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ProductionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Production, System.Guid, Common.Models.Input.ProductionInputModel, Common.Models.Display.ProductionDisplayModel, Common.Models.Filter.ProductionFilterModel>
    {
        public ProductionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/production/productions";
    }
}
