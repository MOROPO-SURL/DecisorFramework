using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationStepWorkPositionBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<ElaborationStepWorkPositionBridgeModel>
{
    public ElaborationStepWorkPositionBridgeConfigurationPage(System.Action<ElaborationStepWorkPositionBridgeModel> successAction, Models.Page.Configuration.ElaborationStepWorkPositionBridgeConfigurationPageModel model) : base(successAction, model)
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
    }

    protected override string EntityTypeName => "Rol en Línea de Producción";

    protected override System.Threading.Tasks.Task<ElaborationStepWorkPositionBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepWorkPositionBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ElaborationStepWorkPositionBridgeModel
        {
            WorkPosition = concreteBindingContext.AvailableWorkPositions[WorkPositionPicker.SelectedIndex],
            Participation = concreteBindingContext.Participation,
            Linked = concreteBindingContext.Linked,
            Description = concreteBindingContext.Description
        });
    }

    protected override System.Threading.Tasks.Task<ElaborationStepWorkPositionBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepWorkPositionBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ElaborationStepWorkPositionBridgeModel
        {
            WorkPosition = concreteBindingContext.AvailableWorkPositions[WorkPositionPicker.SelectedIndex],
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