using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class IndicatorConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<IndicatorDisplayModel, IndicatorDisplayModel, Models.Page.Configuration.IndicatorConfigurationPageModel>
{
    public IndicatorConfigurationPage(System.Action<IndicatorDisplayModel> successIndicator, Models.Page.Configuration.IndicatorConfigurationPageModel model) : base(successIndicator, model, null)
    {
        InitializeComponent();

        if (model.UnitMeasurementId != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurementId != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Indicador";

    protected override System.Threading.Tasks.Task<IndicatorDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new IndicatorDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Priority = ConcreteBindingContext.Priority,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurement = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<IndicatorDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new IndicatorDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Priority = ConcreteBindingContext.Priority,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurement = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex]
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