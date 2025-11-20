using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.EPTCamaguey.Decisor.Terminal.Providers
{
    public class HttpClientHelperProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IReseableHttpClientHelperProviderFacade
    {
        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper { get; private set; }

        public HttpClientHelperProvider()
        {
            Reset();
        }

        public void Reset()
        {
            var settingManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISettingManagerFacade>();

            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                Proxy = !settingManager.UseProxyServer ? null : new System.Net.WebProxy
                {
                    Address = new System.Uri(settingManager.ProxyServerAddress),
                    Credentials = !settingManager.UseProxyAuthentication ? null : new System.Net.NetworkCredential(settingManager.ProxyUsername, settingManager.ProxyPassword)
                },
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, "https://localhost:7208");
        }
    }
}
