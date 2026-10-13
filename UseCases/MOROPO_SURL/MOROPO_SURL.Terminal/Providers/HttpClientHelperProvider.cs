using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace MOROPO.Tool.Decisor.Terminal.Providers;

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

        StringBuilder baseUrlBuilder = new(settingManager.UseApiServerSSL ? "https://" : "http://");

        baseUrlBuilder
            .Append(settingManager.ApiServerAddress)
            .Append(':')
            .Append(settingManager.ApiServerPort);

        var handler = new System.Net.Http.HttpClientHandler
        {
            Proxy = !settingManager.UseProxyServer ? null : new System.Net.WebProxy
            {
                Address = new System.Uri(settingManager.ProxyServerAddress),
                Credentials = !settingManager.UseProxyAuthentication ? null : new System.Net.NetworkCredential(settingManager.ProxyUsername, settingManager.ProxyPassword)
            },
            ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
        };

        HttpClientHelper = new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(handler, baseUrlBuilder.ToString(), GetAuthorizeHeader);

        FFImageLoading.ImageService.Instance.Configuration.HttpClient = new System.Net.Http.HttpClient(handler);
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