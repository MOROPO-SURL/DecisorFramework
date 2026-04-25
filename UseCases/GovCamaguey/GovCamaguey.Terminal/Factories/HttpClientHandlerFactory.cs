using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories;

internal static class HttpClientHandlerFactory
{
    public static System.Net.Http.HttpClientHandler Build()
    {
        var settingManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISettingManagerFacade>();

        return new System.Net.Http.HttpClientHandler
        {
            Proxy = !settingManager.UseProxyServer ? null : new System.Net.WebProxy
            {
                Address = new System.Uri(settingManager.ProxyServerAddress),
                Credentials = !settingManager.UseProxyAuthentication ? null : new System.Net.NetworkCredential(settingManager.ProxyUsername, settingManager.ProxyPassword)
            },
            ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) => true
        };
    }
}
