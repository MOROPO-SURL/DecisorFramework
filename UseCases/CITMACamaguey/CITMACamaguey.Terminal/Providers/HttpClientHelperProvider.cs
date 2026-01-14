using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.CITMACamaguey.Decisor.Terminal.Providers
{
    public class HttpClientHelperProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IReseableHttpClientHelperProviderFacade
    {
#if DEBUG
        private const string SERVER_URI = "https://localhost:7208";

#else
        private const string SERVER_URI = "https://citma.decisor.moropo.cu";
#endif

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
            }, SERVER_URI, GetAuthorizeHeader);
        }

        private System.Collections.Generic.KeyValuePair<string, string> GetAuthorizeHeader()
        {
            var session = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession;

            if (session == null)
            {
                return new System.Collections.Generic.KeyValuePair<string, string>();
            }
            else
            {
                return new System.Collections.Generic.KeyValuePair<string, string>(session.Type, session.Token);
            }
        }
    }
}
