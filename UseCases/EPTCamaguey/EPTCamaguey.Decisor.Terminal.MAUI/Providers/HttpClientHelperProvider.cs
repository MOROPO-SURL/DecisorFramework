namespace MOROPO.EPTCamaguey.Decisor.Terminal.MAUI.Providers
{
    public class HttpClientHelperProvider : Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, "https://localhost:7208");
        }
    }
}
