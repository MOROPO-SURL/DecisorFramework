namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Providers
{
    public class HttpClientHelperProvider : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
#if DEBUG
            var serverBaseUri = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? "https://10.0.2.2:7208" : "https://localhost:7208";
#else
            var serverBaseUri = "https://gobcmg.decisor.moropo.cu";
#endif

            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, serverBaseUri);
        }
    }
}
