namespace MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients
{
    public class ProductionRolesAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractEntityConsultAPIConnectClient<Persistence.Entities.ProductionRole, System.Guid, Common.Models.Display.ProductionRoleDisplayModel>
    {
        public ProductionRolesAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/production/productionroles";
    }
}
