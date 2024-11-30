using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationStepProductionRoleBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<ElaborationStepProductionRoleBridgeModel>
{
    public ElaborationStepProductionRoleBridgeConfigurationPage(System.Action<ElaborationStepProductionRoleBridgeModel> successAction, Models.Page.Configuration.ElaborationStepProductionRoleBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Role != null)
        {
            for (int i = 0; i < model.AvailableRoles.Length; i++)
            {
                var current = model.AvailableRoles[i];

                if (model.Role.Id != current.Id) continue;

                RolePicker.SelectedIndex = i;
                RolePicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Rol en Elaboración";

    protected override System.Threading.Tasks.Task<ElaborationStepProductionRoleBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepProductionRoleBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ElaborationStepProductionRoleBridgeModel
        {
            Role = concreteBindingContext.AvailableRoles[RolePicker.SelectedIndex],
            Participation = concreteBindingContext.Participation,
            Linked = concreteBindingContext.Linked,
            Description = concreteBindingContext.Description
        });
    }

    protected override System.Threading.Tasks.Task<ElaborationStepProductionRoleBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepProductionRoleBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ElaborationStepProductionRoleBridgeModel
        {
            Role = concreteBindingContext.AvailableRoles[RolePicker.SelectedIndex],
            Participation = concreteBindingContext.Participation,
            Linked = concreteBindingContext.Linked,
            Description = concreteBindingContext.Description
        });
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}