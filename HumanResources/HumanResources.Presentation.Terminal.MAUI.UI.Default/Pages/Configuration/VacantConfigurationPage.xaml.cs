namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VacantConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Models.View.VacantViewModel>
{
    public VacantConfigurationPage(System.Action<Models.View.VacantViewModel> successAction, Models.Page.Configuration.VacantConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.WorkPosition != null)
        {
            for (int i = 0; i < model.AvailableWorkPositions.Length; i++)
            {
                var current = model.AvailableWorkPositions[i];

                if (model.WorkPosition.Id != current.Id) continue;

                WorkPositionPicker.SelectedIndex = i;
                WorkPositionPicker.SelectedItem = current;

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
                SalaryStandardPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Vacante";

    protected override System.Threading.Tasks.Task<Models.View.VacantViewModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.VacantConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Models.View.VacantViewModel
        {
            Id = System.Guid.NewGuid(),
            OrganizationUnity = concreteBindingContext.OrganizationUnity,
            Priority = concreteBindingContext.Priority,
            NamingResolutionRequired = concreteBindingContext.NamingResolutionRequired,
            WorkPosition = concreteBindingContext.AvailableWorkPositions[WorkPositionPicker.SelectedIndex],
            SalaryStandard = concreteBindingContext.AvailableSalaryStandards[SalaryStandardPicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<Models.View.VacantViewModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.VacantConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Models.View.VacantViewModel
        {
            Id = concreteBindingContext.Id,
            OrganizationUnity = concreteBindingContext.OrganizationUnity,
            Priority = concreteBindingContext.Priority,
            NamingResolutionRequired = concreteBindingContext.NamingResolutionRequired,
            WorkPosition = concreteBindingContext.AvailableWorkPositions[WorkPositionPicker.SelectedIndex],
            SalaryStandard = concreteBindingContext.AvailableSalaryStandards[SalaryStandardPicker.SelectedIndex]
        });
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}