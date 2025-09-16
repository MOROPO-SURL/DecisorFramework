using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseZoneSpentBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel, Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel, Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel>
{
    public PurchaseZoneSpentBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> successAction, Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();

        if (model.Currency != null)
        {
            for (int i = 0; i < model.AvailableCurrrencies.Length; i++)
            {
                var current = model.AvailableCurrrencies[i];

                if (model.Currency.Id != current.Id) continue;

                CurrencyPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Gasto por Zona";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel
        {
            Spent = ConcreteBindingContext.Spent,
            Amount = ConcreteBindingContext.Amount,
            Currency = ConcreteBindingContext.AvailableCurrrencies[CurrencyPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel
        {
            Spent = ConcreteBindingContext.Spent,
            Amount = ConcreteBindingContext.Amount,
            Currency = ConcreteBindingContext.AvailableCurrrencies[CurrencyPicker.SelectedIndex]
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void CurrencyPicker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void SpentPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PurchaseSpentPickPage(SpentPickComplete_Callback)));
    }

    private void SpentPickComplete_Callback(Interop.API.Common.Models.Display.PurchaseSpentDisplayModel model)
    {
        ConcreteBindingContext.Spent = model;

        hasChangesFlag = true;
    }
}