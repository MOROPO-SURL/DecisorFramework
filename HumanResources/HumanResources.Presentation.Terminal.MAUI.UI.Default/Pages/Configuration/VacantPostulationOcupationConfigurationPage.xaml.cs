namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VacantPostulationOcupationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel, Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel, Models.Page.Configuration.VacantPostulationOcupationConfigurationPageModel>
{
    public VacantPostulationOcupationConfigurationPage(System.Action<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel> successAction, Models.Page.Configuration.VacantPostulationOcupationConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.CentralStateStructure != null)
        {
            for (int i = 0; i < model.AvailableCentralStateStructures.Length; i++)
            {
                var current = model.AvailableCentralStateStructures[i];

                if (model.CentralStateStructure.Id != current.Id) continue;

                CentralStateStructurePicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Ocupación Anterior";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel> PerformCreationAsync()
    {
        var model = new Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel
        {
            Id = System.Guid.NewGuid(),
            OrganizationName = ConcreteBindingContext.OrganizationName,
            OrganizationAddress = ConcreteBindingContext.OrganizationAddress,
            CentralStateStructure = ConcreteBindingContext.AvailableCentralStateStructures[CentralStateStructurePicker.SelectedIndex],
            RepresentativeName = ConcreteBindingContext.RepresentativeName,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt
        };

        return System.Threading.Tasks.Task.FromResult(model);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel> PerformEditionAsync()
    {
        var model = new Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            OrganizationName = ConcreteBindingContext.OrganizationName,
            OrganizationAddress = ConcreteBindingContext.OrganizationAddress,
            CentralStateStructure = ConcreteBindingContext.AvailableCentralStateStructures[CentralStateStructurePicker.SelectedIndex],
            RepresentativeName = ConcreteBindingContext.RepresentativeName,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt
        };

        return System.Threading.Tasks.Task.FromResult(model);
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