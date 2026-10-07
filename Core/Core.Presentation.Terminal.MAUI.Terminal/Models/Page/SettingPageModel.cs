using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page;

public class SettingPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
{
    public static string ApiServerAddressValidableProperty => nameof(ApiServerAddress);
    public static string ApiServerPortValidableProperty => nameof(ApiServerPort);
    public static string ProxyServerAddressValidableProperty => nameof(ProxyServerAddress);
    public static string ProxyUsernameValidableProperty => nameof(ProxyUsername);
    public static string ProxyPasswordValidableProperty => nameof(ProxyPassword);

    private string apiServerAddress;
    private bool useApiServerSSL;
    private int apiServerPort;
    private bool useProxyServer;
    private string proxyServerAddress;
    private bool useProxyAuthentication;
    private string proxyUsername;
    private string proxyPassword;
    private FluentValidation.Results.ValidationResult validationResult;

    private readonly System.Action validationCallbackAction;

    public SettingPageModel(System.Action applySuccessCallbackAction, System.Action validationCallbackAction)
    {
        this.validationCallbackAction = validationCallbackAction;

        var settingManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISettingManagerFacade>();

        apiServerAddress = settingManager.ApiServerAddress;
        useApiServerSSL = settingManager.UseApiServerSSL;
        apiServerPort = settingManager.ApiServerPort;
        useProxyServer = settingManager.UseProxyServer;
        proxyServerAddress = settingManager.ProxyServerAddress;
        useProxyAuthentication = settingManager.UseProxyAuthentication;
        proxyUsername = settingManager.ProxyUsername;
        proxyPassword = settingManager.ProxyPassword;

        ApplyChangesCommand = new Microsoft.Maui.Controls.Command(
            execute: () =>
            {
                var validator = new Validators.SettingValidator();

                ValidationResult = null;
                ValidationResult = validator.Validate(this);

                if (!ValidationResult.IsValid) return;

                settingManager.ApiServerAddress = apiServerAddress;
                settingManager.UseApiServerSSL = useApiServerSSL;
                settingManager.ApiServerPort = apiServerPort;
                settingManager.UseProxyServer = useProxyServer;
                settingManager.ProxyServerAddress = proxyServerAddress;
                settingManager.UseProxyAuthentication = useProxyAuthentication;
                settingManager.ProxyUsername = proxyUsername;
                settingManager.ProxyPassword = proxyPassword;

                applySuccessCallbackAction.Invoke();
            }
        );
    }

    public System.Windows.Input.ICommand ApplyChangesCommand { get; private set; }

    public string ApiServerAddress { get => apiServerAddress; set => SetProperty(ref apiServerAddress, value); }

    public bool UseApiServerSSL { get => useApiServerSSL; set => SetProperty(ref useApiServerSSL, value, UseApiServerSSLChange_Callback); }

    public int ApiServerPort { get => apiServerPort; set => SetProperty(ref apiServerPort, value); }

    public bool UseProxyServer { get => useProxyServer; set => SetProperty(ref useProxyServer, value); }

    public string ProxyServerAddress { get => proxyServerAddress; set => SetProperty(ref proxyServerAddress, value); }

    public bool UseProxyAuthentication { get => useProxyAuthentication; set => SetProperty(ref useProxyAuthentication, value); }

    public string ProxyUsername { get => proxyUsername; set => SetProperty(ref proxyUsername, value); }

    public string ProxyPassword { get => proxyPassword; set => SetProperty(ref proxyPassword, value); }

    public FluentValidation.Results.ValidationResult ValidationResult { get => validationResult; set => SetProperty(ref validationResult, value, validationCallbackAction); }

    private void UseApiServerSSLChange_Callback()
    {
        ApiServerPort = UseApiServerSSL ? 443 : 80;
    }
}