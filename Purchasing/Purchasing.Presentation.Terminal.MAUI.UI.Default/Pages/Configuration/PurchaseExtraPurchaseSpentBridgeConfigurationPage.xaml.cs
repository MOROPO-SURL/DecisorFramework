using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseExtraPurchaseSpentBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Models.View.PurchasePurchaseSpentBridgeViewModel>
{
    public PurchaseExtraPurchaseSpentBridgeConfigurationPage(System.Action<Models.View.PurchasePurchaseSpentBridgeViewModel> successAction, Models.Page.Configuration.PurchaseExtraPurchaseSpentBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        //if (model.CostCenter != null)
        //{
        //    for (int i = 0; i < model.AvailableCostCenters.Length; i++)
        //    {
        //        var current = model.AvailableCostCenters[i];

        //        if (model.CostCenter.Id != current.Id) continue;

        //        CostCenterPicker.SelectedIndex = i;
        //        CostCenterPicker.SelectedItem = current;

        //        break;
        //    }
        //}
    }

    protected override string EntityTypeName => "Costo Extra de Compra";

    protected override System.Threading.Tasks.Task<Models.View.PurchasePurchaseSpentBridgeViewModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseExtraPurchaseSpentBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Models.View.PurchasePurchaseSpentBridgeViewModel
        {
            Spent = concreteBindingContext.Spent,
            Amount = concreteBindingContext.Amount,
            Count = concreteBindingContext.Count,
            CostCenter = concreteBindingContext.CostCenter
        });
    }

    protected override System.Threading.Tasks.Task<Models.View.PurchasePurchaseSpentBridgeViewModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseExtraPurchaseSpentBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Models.View.PurchasePurchaseSpentBridgeViewModel
        {
            Spent = concreteBindingContext.Spent,
            Amount = concreteBindingContext.Amount,
            Count = concreteBindingContext.Count,
            CostCenter = concreteBindingContext.CostCenter
        });
    }

    private void SpentPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PurchaseSpentPickPage(SpentPickComplete_Callback)));
    }

    private void SpentPickComplete_Callback(Interop.API.Common.Models.Display.PurchaseSpentDisplayModel model)
    {
        ((Models.Page.Configuration.PurchaseExtraPurchaseSpentBridgeConfigurationPageModel)BindingContext).Spent = model;

        hasChangesFlag = true;
    }
}