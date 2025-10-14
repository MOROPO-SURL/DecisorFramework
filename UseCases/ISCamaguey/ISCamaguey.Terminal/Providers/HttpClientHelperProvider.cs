namespace MOROPO.ISCamaguey.Decisor.Terminal.Providers
{
    public class HttpClientHelperProvider : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
#if DEBUG
            var baseUrl = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? "https://192.168.64.21:7208" : "https://localhost:7208";
#else
            var baseUrl = "https://iscmg.decisor.moropo.cu";
#endif

            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, baseUrl);
        }
    }
}
