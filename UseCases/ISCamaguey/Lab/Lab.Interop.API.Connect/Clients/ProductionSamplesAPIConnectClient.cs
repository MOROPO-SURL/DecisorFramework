namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class ProductionSamplesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ProductionSample, System.Guid, Common.Models.Input.ProductionSampleInputModel, Common.Models.Display.ProductionSampleDisplayModel, Common.Models.Filter.CommonSampleFilterModel<Common.Models.Display.ProductionSampleDisplayModel, Persistence.Entities.ProductionSample>>
    {
        public ProductionSamplesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/productionsamples";
    }
}