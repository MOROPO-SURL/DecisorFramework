namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class BrandsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.Brand, System.Guid, Common.Models.Input.BrandInputModel, Common.Models.Display.BrandDisplayModel>
    {
        public BrandsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/domain/brands";
    }
}
