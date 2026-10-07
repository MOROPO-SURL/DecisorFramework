namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade
{
    public interface ISettingManagerFacade
    {
        string ApiServerAddress { get; set; }

        bool UseApiServerSSL { get; set; }

        int ApiServerPort { get; set; }

        bool UseProxyServer { get; set; }

        string ProxyServerAddress { get; set; }

        bool UseProxyAuthentication { get; set; }

        string ProxyUsername { get; set; }

        string ProxyPassword { get; set; }
    }
}
