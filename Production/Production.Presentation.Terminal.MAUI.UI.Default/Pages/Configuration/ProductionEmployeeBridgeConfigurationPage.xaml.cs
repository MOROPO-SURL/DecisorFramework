using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionEmployeeBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<ProductionEmployeeBridgeModel>
{
    public ProductionEmployeeBridgeConfigurationPage(System.Action<ProductionEmployeeBridgeModel> successAction, Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Step != null)
        {
            for (int i = 0; i < model.AvailableSteps.Length; i++)
            {
                var current = model.AvailableSteps[i];

                if (model.Step.Id != current.Id) continue;

                StepPicker.SelectedIndex = i;
                StepPicker.SelectedItem = current;

                var index = -1;

                for (var y = 0; y < current.ProductionRoles.Length; y++)
                {
                    var item = current.ProductionRoles[y];

                    model.AvailableRoles.Add(item.Role);

                    if (y != -1) continue;

                    if (model.Role.Id == item.Role.Id) index = y;
                }

                RolePicker.SelectedIndex = index;
            }
        }
    }

    protected override string EntityTypeName => "Participación de Empleado";

    protected override System.Threading.Tasks.Task<ProductionEmployeeBridgeModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ProductionEmployeeBridgeModel
        {
            Employee = concreteBindingContext.Employee,
            Step = concreteBindingContext.AvailableSteps[StepPicker.SelectedIndex],
            Role = concreteBindingContext.AvailableRoles[RolePicker.SelectedIndex]
        });
    }

    protected override System.Threading.Tasks.Task<ProductionEmployeeBridgeModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new ProductionEmployeeBridgeModel
        {
            Employee = concreteBindingContext.Employee,
            Step = concreteBindingContext.AvailableSteps[StepPicker.SelectedIndex],
            Role = concreteBindingContext.AvailableRoles[RolePicker.SelectedIndex]
        });
    }

    private void EmployeePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(EmployeePickComplete_Callback)));
    }

    private void EmployeePickComplete_Callback(HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ((Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel)BindingContext).Employee = model;

        hasChangesFlag = true;
    }

    private void StepPicker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (StepPicker.SelectedIndex == -1) return;

        var concreteBindingContext = (Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel)BindingContext;

        var current = concreteBindingContext.AvailableSteps[StepPicker.SelectedIndex];

        concreteBindingContext.AvailableRoles.Clear();

        for (var y = 0; y < current.ProductionRoles.Length; y++)
        {
            var item = current.ProductionRoles[y];

            concreteBindingContext.AvailableRoles.Add(item.Role);
        }

        hasChangesFlag = true;
    }

    private void RolePicker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}