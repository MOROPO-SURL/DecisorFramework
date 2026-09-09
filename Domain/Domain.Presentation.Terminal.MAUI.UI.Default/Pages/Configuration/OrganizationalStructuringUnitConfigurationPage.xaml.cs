namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OrganizationalStructuringUnitConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel, Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel, Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel>
{
    public OrganizationalStructuringUnitConfigurationPage(System.Action<Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel> successAction, Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();

        if (model.OrganizationalUnit != null)
        {
            for (int i = 0; i < model.AvailableOrganizationalUnits.Count; i++)
            {
                var current = model.AvailableOrganizationalUnits[i];

                if (model.OrganizationalUnit.Id != current.Id) continue;

                OrganizativeUnitPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Unidad Organizativa en Estructura Organizacional";

    protected override System.Threading.Tasks.Task<Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(ConcreteBindingContext);
    }

    protected override System.Threading.Tasks.Task<Models.Page.Configuration.OrganizationalStructuringUnitConfigurationPageModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(ConcreteBindingContext);
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