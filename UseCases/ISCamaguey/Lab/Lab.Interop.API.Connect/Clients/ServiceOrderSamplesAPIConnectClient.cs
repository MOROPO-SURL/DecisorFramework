namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class ServiceOrderSamplesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementFilteredAPIConnectClient<Persistence.Entities.ServiceOrderSample, System.Guid, Common.Models.Input.ServiceOrderSampleInputModel, Common.Models.Display.ServiceOrderSampleDisplayModel, Common.Models.Filter.CommonSampleFilterModel<Common.Models.Display.ServiceOrderSampleDisplayModel, Persistence.Entities.ServiceOrderSample>>
    {
        public ServiceOrderSamplesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/serviceordersamples";
    }
}