namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages.Configuration;

public partial class SimplifiedVacantConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel>
{
    public SimplifiedVacantConfigurationPage(System.Action<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel> successAction, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel model, FluentValidation.AbstractValidator<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.VacantConfigurationPageModel> validator) : base(successAction, model, validator)
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

        ConcreteBindingContext.OcupationMode = Framework.Decisor.HumanResources.Persistence.Enumerations.VacantOcupationMode.Naming;
    }

    protected override bool IsNotificationRequired => false;

    protected override string EntityTypeName => "Vacante";

    protected override System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel
        {
            Id = System.Guid.NewGuid(),
            OrganizationUnity = ConcreteBindingContext.OrganizationUnity,
            Priority = ConcreteBindingContext.Priority,
            OcupationMode = ConcreteBindingContext.OcupationMode,
            WorkPosition = ConcreteBindingContext.WorkPosition,
            SalaryStandard = ConcreteBindingContext.SalaryStandard
        });
    }

    protected override System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.WorkforceConfigurationVacantViewModel
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