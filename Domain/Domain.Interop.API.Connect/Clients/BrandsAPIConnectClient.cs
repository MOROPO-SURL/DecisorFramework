namespace MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients
{
    public class BrandsAPIConnectClient : Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.Brand, System.Guid, Common.Models.Input.BrandInputModel, Common.Models.Display.BrandDisplayModel, Common.Models.Filter.BrandFilterModel>
    {
        public BrandsAPIConnectClient(Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/fwrk/domain/brands";
    }
}
