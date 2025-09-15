using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class IndicatorMontlyPlanConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<IndicatorMontlyPlanInputModel, IndicatorMontlyPlanInputModel, Models.Page.Configuration.IndicatorMontlyPlanConfigurationPageModel>
{
    public IndicatorMontlyPlanConfigurationPage(System.Action<IndicatorMontlyPlanInputModel> successIndicator, Models.Page.Configuration.IndicatorMontlyPlanConfigurationPageModel model) : base(successIndicator, model, new Validators.IndicatorMontlyPlanConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Plan Mensual de Indicador";

    protected override System.Threading.Tasks.Task<IndicatorMontlyPlanInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new IndicatorMontlyPlanInputModel
        {
            Id = System.Guid.NewGuid(),
            Month = ConcreteBindingContext.YearMonth.Value,
            Year = ConcreteBindingContext.YearMonth.Key,
            Amount = ConcreteBindingContext.Amount
        });
    }

    protected override System.Threading.Tasks.Task<IndicatorMontlyPlanInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new IndicatorMontlyPlanInputModel
        {
            Id = ConcreteBindingContext.Id,
            Month = ConcreteBindingContext.YearMonth.Value,
            Year = ConcreteBindingContext.YearMonth.Key,
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}