namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Connect.Clients
{
    public class CubanStandardsAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.CubanStandard, System.Guid, Common.Models.Input.CubanStandardInputModel, Common.Models.Display.CubanStandardDisplayModel, Common.Models.Filter.CubanStandardFilterModel>
    {
        public CubanStandardsAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/quality/cubanstandards";
    }
}
