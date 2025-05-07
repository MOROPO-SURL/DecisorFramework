namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class UnitMeasurementConvertionBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel, Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel, Models.Page.Configuration.UnitMeasurementConvertionBridgeConfigurationPageModel>
{
    public UnitMeasurementConvertionBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> successAction, Models.Page.Configuration.UnitMeasurementConvertionBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Destination != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.Destination.Id != current.Id) continue;

                DestinationUnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Conversión de Unidad de Medida";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel
        {
            Destination = ConcreteBindingContext.AvailableUnitMeasurements[DestinationUnitMeasurementPicker.SelectedIndex],
            Convertion = ConcreteBindingContext.Convertion
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel
        {
            Destination = ConcreteBindingContext.Destination,
            Convertion = ConcreteBindingContext.Convertion
        });
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}