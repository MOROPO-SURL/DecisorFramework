namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Connect.Clients
{
    public class ServiceOrderSamplesAPIConnectClient : Framework.Guama.Core.Presentation.API.Connect.Clients.Contract.AbstractArchivableEnableableEntityManagementAPIConnectClient<Persistence.Entities.ServiceOrderSample, long, Common.Models.Input.ServiceOrderSampleInputModel, Common.Models.Display.ServiceOrderSampleDisplayModel>
    {
        public ServiceOrderSamplesAPIConnectClient(Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade httpClientHelperProvider) : base(httpClientHelperProvider)
        {
        }

        protected override string TargetController => "api/lab/serviceordersamples";
    }
}