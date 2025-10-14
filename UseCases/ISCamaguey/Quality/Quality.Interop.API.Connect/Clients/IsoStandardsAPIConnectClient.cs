namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients
{
    public class IsoStandardsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.IsoStandard, System.Guid, Common.Models.Input.IsoStandardInputModel, Common.Models.Display.IsoStandardDisplayModel, Common.Models.Filter.IsoStandardFilterModel>
    {
        public IsoStandardsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/quality/isostandards";
    }
}
