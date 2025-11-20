namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WarehousingAreaConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Interop.API.Common.Models.Display.WarehousingAreaDisplayModel, Models.Page.Configuration.WarehousingAreaConfigurationPageModel>
{
    public WarehousingAreaConfigurationPage(System.Action<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> successAction, Models.Page.Configuration.WarehousingAreaConfigurationPageModel model) : base(successAction, model, null)
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

        if (model.Family != null)
        {
            for (int i = 0; i < model.AvailableFamilies.Length; i++)
            {
                var current = model.AvailableFamilies[i];

                if (model.Family.Id != current.Id) continue;

                FamilyPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Área de Almacenamiento";

    protected override bool IsNotificationRequired => false;

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.WarehousingAreaDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Capacity = ConcreteBindingContext.Capacity,
            UnitMeasurement = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex],
            Description = ConcreteBindingContext.Description,
            Family = ConcreteBindingContext.AvailableFamilies[FamilyPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.WarehousingAreaDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Capacity = ConcreteBindingContext.Capacity,
            UnitMeasurement = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex],
            Description = ConcreteBindingContext.Description,
            Family = ConcreteBindingContext.AvailableFamilies[FamilyPicker.SelectedIndex]
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