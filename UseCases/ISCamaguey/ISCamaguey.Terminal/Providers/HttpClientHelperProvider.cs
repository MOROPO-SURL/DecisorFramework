using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Terminal.Providers
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
#if DEBUG
            var baseUrl = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? "https://192.168.64.21:7208" : "https://localhost:7208";
#else
            var baseUrl = "http://192.168.0.12";
#endif
            var settingManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISettingManagerFacade>();

            HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(new System.Net.Http.HttpClientHandler
            {
                Proxy = !settingManager.UseProxyServer ? null : new System.Net.WebProxy
                {
                    Address = new System.Uri(settingManager.ProxyServerAddress),
                    Credentials = !settingManager.UseProxyAuthentication ? null : new System.Net.NetworkCredential(settingManager.ProxyUsername, settingManager.ProxyPassword)
                },
                ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
            }, baseUrl, GetAuthorizeHeader);
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
