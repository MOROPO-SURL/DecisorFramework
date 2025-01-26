namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ProductionsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEntityManagementAPIConnectClient<Persistence.Entities.Production, System.Guid, Common.Models.Input.ProductionInputModel, Common.Models.Display.ProductionDisplayModel>
    {
        public ProductionsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/production/productions";
    }
}
