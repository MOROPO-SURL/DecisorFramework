using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchasePlanCommonProductBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel>
{
    public PurchasePlanCommonProductBridgeConfigurationPage(string entityTypeName, System.Action<Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel> successAction, Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;
                UnitMeasurementPicker.SelectedItem = current;

                break;
            }
        }

        if (model.OnEditionMode)
        {
            Title = $"Modificar {entityTypeName}";
        }
        else
        {
            Title = $"Agregar {entityTypeName}";
        }
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    if (((Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel)BindingContext).Product != null) return;

    //    this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new ProductPickPage(ProductPickComplete_Callback)));
    //}

    protected override string EntityTypeName => string.Empty;

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel
        {
           Product = concreteBindingContext.Product,
           Amount = concreteBindingContext.Amount,
           UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchasePlanCommonProductBridgeModel
        {
            Product = concreteBindingContext.Product,
            Amount = concreteBindingContext.Amount,
            UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex]
        });
    }

    private void ProductChangeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(ProductPickComplete_Callback)));
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ((Models.Page.Configuration.PurchasePlanCommonProductBridgeConfigurationPageModel)BindingContext).Product = model;

        hasChangesFlag = true;
    }
}