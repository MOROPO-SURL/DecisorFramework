using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseCommonProductBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel>
{
    public PurchaseCommonProductBridgeConfigurationPage(string entityTypeName, System.Action<Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel> successAction, Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;

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

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel
        {
           Product = concreteBindingContext.Product,
           Amount = concreteBindingContext.Amount,
           UnitMeasurement = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel
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
        ((Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel)BindingContext).Product = model;

        hasChangesFlag = true;
    }
}