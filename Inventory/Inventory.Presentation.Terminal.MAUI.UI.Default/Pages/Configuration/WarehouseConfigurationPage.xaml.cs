using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WarehouseConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.WarehouseDisplayModel>
{
    public WarehouseConfigurationPage(System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel> successAction, Models.Page.Configuration.WarehouseConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Almacen";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehouseDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WarehousesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.WarehouseConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.WarehouseInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehouseDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WarehousesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.WarehouseConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.WarehouseInputModel
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