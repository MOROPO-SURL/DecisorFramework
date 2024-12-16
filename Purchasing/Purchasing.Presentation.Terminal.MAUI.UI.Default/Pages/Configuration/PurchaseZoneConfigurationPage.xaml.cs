using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseZoneConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
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
            Priority = concreteBindingContext.Priority,
            SpentBridges = concreteBindingContext.SpentBridges.ToList()
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
            Priority = concreteBindingContext.Priority,
            SpentBridges = concreteBindingContext.SpentBridges.ToList()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void AddSpentBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new PurchaseZoneSpentBridgeConfigurationPage(SpentBridgeCreateSuccess_Callback, new Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel()));
    }

    private void EditSpentBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new PurchaseZoneSpentBridgeConfigurationPage(SpentBridgeEditSuccess_Callback, new Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel)));
    }

    private void SpentBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta gasto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchaseZoneConfigurationPageModel)BindingContext).SpentBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel));
        });
    }

    private void SpentBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel model)
    {
        ((Models.Page.Configuration.PurchaseZoneConfigurationPageModel)BindingContext).SpentBridges.Add(model);

        hasChangesFlag = true;
    }

    private void SpentBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseZoneConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.SpentBridges.First(item => item.Spent.Id == model.Spent.Id);

        var index = concreteBindingContext.SpentBridges.IndexOf(reference);

        concreteBindingContext.SpentBridges[index] = model;

        hasChangesFlag = true;
    }
}