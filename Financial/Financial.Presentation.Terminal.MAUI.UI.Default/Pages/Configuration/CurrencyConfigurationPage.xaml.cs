using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CurrencyConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.CurrencyDisplayModel>
{
    public CurrencyConfigurationPage(System.Action<Interop.API.Common.Models.Display.CurrencyDisplayModel> successAction, Models.Page.Configuration.CurrencyConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Moneda";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CurrencyDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CurrencyConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CurrencyInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Symbol = concreteBindingContext.Symbol,
            UseEndSymbolPresentation = concreteBindingContext.UseEndSymbolPresentation,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CurrencyDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CurrencyConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CurrencyInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Symbol = concreteBindingContext.Symbol,
            UseEndSymbolPresentation = concreteBindingContext.UseEndSymbolPresentation,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }
}