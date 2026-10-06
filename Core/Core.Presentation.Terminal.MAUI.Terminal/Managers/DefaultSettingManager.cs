namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers
{
    public class DefaultSettingManager : Facade.ISettingManagerFacade
    {
        private const string USE_API_SERVER_SSL_KEY = "use_api_server_ssl";
        private const string API_SERVER_ADDRESS_KEY = "api_server_address";
        private const string API_SERVER_PORT_KEY = "api_server_port";
        private const string USE_PROXY_SERVER_KEY = "use_proxy_server";
        private const string PROXY_SERVER_ADDRESS_KEY = "proxy_server_address";
        private const string USE_PROXY_AUTHENTICATION_KEY = "use_proxy_authentication";
        private const string PROXY_USERNAME_KEY = "proxy_username";
        private const string PROXY_PASSWORD_KEY = "proxy_password";

        public string ApiServerAddress
        {
            get => Microsoft.Maui.Storage.Preferences.Get(API_SERVER_ADDRESS_KEY, "127.0.0.1");
            set => Microsoft.Maui.Storage.Preferences.Set(API_SERVER_ADDRESS_KEY, value);
        }

        public bool UseApiServerSSL
        {
            get => Microsoft.Maui.Storage.Preferences.Get(USE_API_SERVER_SSL_KEY, false);
            set => Microsoft.Maui.Storage.Preferences.Set(USE_API_SERVER_SSL_KEY, value);
        }

        public int ApiServerPort
        {
            get => Microsoft.Maui.Storage.Preferences.Get(API_SERVER_PORT_KEY, 80);
            set => Microsoft.Maui.Storage.Preferences.Set(API_SERVER_PORT_KEY, value);
        }

        public bool UseProxyServer 
        { 
            get => Microsoft.Maui.Storage.Preferences.Get(USE_PROXY_SERVER_KEY, false); 
            set => Microsoft.Maui.Storage.Preferences.Set(USE_PROXY_SERVER_KEY, value);
        }

        public string ProxyServerAddress 
        {
            get => Microsoft.Maui.Storage.Preferences.Get(PROXY_SERVER_ADDRESS_KEY, string.Empty);
            set => Microsoft.Maui.Storage.Preferences.Set(PROXY_SERVER_ADDRESS_KEY, value);
        }

        public bool UseProxyAuthentication
        {
            get => Microsoft.Maui.Storage.Preferences.Get(USE_PROXY_AUTHENTICATION_KEY, false);
            set => Microsoft.Maui.Storage.Preferences.Set(USE_PROXY_AUTHENTICATION_KEY, value);
        }

        public string ProxyUsername 
        {
            get => Microsoft.Maui.Storage.Preferences.Get(PROXY_USERNAME_KEY, string.Empty);
            set => Microsoft.Maui.Storage.Preferences.Set(PROXY_USERNAME_KEY, value);
        }

        public string ProxyPassword 
        {
            get => Microsoft.Maui.Storage.Preferences.Get(PROXY_PASSWORD_KEY, string.Empty);
            set => Microsoft.Maui.Storage.Preferences.Set(PROXY_PASSWORD_KEY, value);
        }
    }
}
