using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProjectBudgetFunancingConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel, Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel, Models.Page.Configuration.ProjectBudgetFunancingConfigurationPageModel>
{
    public ProjectBudgetFunancingConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel> successAction, Models.Page.Configuration.ProjectBudgetFunancingConfigurationPageModel model) : base(successAction, model, new Validators.ProjectBudgetFunancingConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Finaciamiento";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Financier = ConcreteBindingContext.Financier,
            Currency = ConcreteBindingContext.Currency,
            Amount = ConcreteBindingContext.Amount
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Financier = ConcreteBindingContext.Financier,
            Currency = ConcreteBindingContext.Currency,
            Amount = ConcreteBindingContext.Amount
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

    private void FinancierPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.FinancierPickPage(FinancierPickComplete_Callback)));
    }

    private void FinancierPickComplete_Callback(Interop.API.Common.Models.Display.FinancierDisplayModel model)
    {
        ConcreteBindingContext.Financier = model;

        hasChangesFlag = true;
    }
}