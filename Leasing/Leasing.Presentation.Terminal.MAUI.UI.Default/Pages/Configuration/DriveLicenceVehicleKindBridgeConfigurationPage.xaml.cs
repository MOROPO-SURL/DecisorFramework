namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DriveLicenceVehicleKindBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel, Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel, Models.Page.Configuration.DriveLicenceVehicleKindBridgeConfigurationPageModel>
{
    public DriveLicenceVehicleKindBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel> successAction, Models.Page.Configuration.DriveLicenceVehicleKindBridgeConfigurationPageModel model) : base(successAction, model, new Validators.DriveLicenceVehicleKindBridgeConfigurationValidator())
    {
        InitializeComponent();

        if (model.Stern != null)
        {
            for (int i = 0; i < model.AvailableVehicleKinds.Length; i++)
            {
                var current = model.AvailableVehicleKinds[i];

                if (model.Stern.Id != current.Id) continue;

                VehicleKindPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Categoría de Licencia de Conducción";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel
        {
            Stern = ConcreteBindingContext.Stern,
            Category = ConcreteBindingContext.Category,
            Specification = ConcreteBindingContext.Specification,
            AchievedAt = new System.DateTime(ConcreteBindingContext.AchievedAtYear, ConcreteBindingContext.AchievedAtMonth, 1)
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel
        {
            Stern = ConcreteBindingContext.Stern,
            Category = ConcreteBindingContext.Category,
            Specification = ConcreteBindingContext.Specification,
            AchievedAt = new System.DateTime(ConcreteBindingContext.AchievedAtYear, ConcreteBindingContext.AchievedAtMonth, 1)
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