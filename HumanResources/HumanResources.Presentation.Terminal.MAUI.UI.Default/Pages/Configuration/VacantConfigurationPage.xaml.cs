namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VacantConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.View.WorkforceConfigurationVacantViewModel, Models.View.WorkforceConfigurationVacantViewModel, Models.Page.Configuration.VacantConfigurationPageModel>
{
    public VacantConfigurationPage(System.Action<Models.View.WorkforceConfigurationVacantViewModel> successAction, Models.Page.Configuration.VacantConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.VacantConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.WorkPosition != null)
        {
            for (int i = 0; i < model.AvailableWorkPositions.Length; i++)
            {
                var current = model.AvailableWorkPositions[i];

                if (model.WorkPosition.Id != current.Id) continue;

                WorkPositionPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.SalaryStandard != null)
        {
            for (int i = 0; i < model.AvailableSalaryStandards.Length; i++)
            {
                var current = model.AvailableSalaryStandards[i];

                if (model.SalaryStandard.Id != current.Id) continue;

                SalaryStandardPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Vacante";

    protected override System.Threading.Tasks.Task<Models.View.WorkforceConfigurationVacantViewModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Models.View.WorkforceConfigurationVacantViewModel
        {
            Id = System.Guid.NewGuid(),
            OrganizationUnity = ConcreteBindingContext.OrganizationUnity,
            Priority = ConcreteBindingContext.Priority,
            OcupationMode = ConcreteBindingContext.OcupationMode,
            WorkPosition = ConcreteBindingContext.WorkPosition,
            SalaryStandard = ConcreteBindingContext.SalaryStandard
        });
    }

    protected override System.Threading.Tasks.Task<Models.View.WorkforceConfigurationVacantViewModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Models.View.WorkforceConfigurationVacantViewModel
        {
            Id = ConcreteBindingContext.Id,
            OrganizationUnity = ConcreteBindingContext.OrganizationUnity,
            Priority = ConcreteBindingContext.Priority,
            OcupationMode = ConcreteBindingContext.OcupationMode,
            WorkPosition = ConcreteBindingContext.WorkPosition,
            SalaryStandard = ConcreteBindingContext.SalaryStandard
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