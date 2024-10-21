namespace MOROPO.Framework.Decisor.UseCase.Terminal.MAUI.Providers
{
    public class HttpClientHelperProvider : Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        public Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
            HttpClientHelper = new Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, "https://localhost:7208");
        }
    }
}
