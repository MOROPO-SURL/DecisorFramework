using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Pages.Configuration;

public partial class PurchaseZoneConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
{
    public PurchaseZoneConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> successAction, Models.Page.Configuration.PurchaseZoneConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Zona de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseZoneConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseZoneInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseZoneConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseZoneInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }
}