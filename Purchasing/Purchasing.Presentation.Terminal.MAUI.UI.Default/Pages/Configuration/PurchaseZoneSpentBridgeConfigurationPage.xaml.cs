using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseZoneSpentBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel>
{
    public PurchaseZoneSpentBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> successAction, Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Costo por Zona";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel
        {
            Spent = concreteBindingContext.Spent,
            Amount = concreteBindingContext.Amount
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.PurchaseZoneSpentBridgeModel
        {
            Spent = concreteBindingContext.Spent,
            Amount = concreteBindingContext.Amount
        });
    }

    private void SpentPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PurchaseSpentPickPage(SpentPickComplete_Callback)));
    }

    private void SpentPickComplete_Callback(Interop.API.Common.Models.Display.PurchaseSpentDisplayModel model)
    {
        ((Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel)BindingContext).Spent = model;

        hasChangesFlag = true;
    }
}