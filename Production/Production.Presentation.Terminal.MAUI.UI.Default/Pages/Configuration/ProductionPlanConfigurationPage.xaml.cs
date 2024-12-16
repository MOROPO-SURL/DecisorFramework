using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionPlanConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<ProductionPlanDisplayModel>
{
    public ProductionPlanConfigurationPage(System.Action<ProductionPlanDisplayModel> successAction, Models.Page.Configuration.ProductionPlanConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Planner != null)
        {
            for (int i = 0; i < model.AvailablePlanners.Length; i++)
            {
                var current = model.AvailablePlanners[i];

                if (model.Planner.Id != current.Id) continue;

                PlannerPicker.SelectedIndex = i;
                PlannerPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Responsible != null)
        {
            for (int i = 0; i < model.AvailableResponsibles.Length; i++)
            {
                var current = model.AvailableResponsibles[i];

                if (model.Responsible.Id != current.Id) continue;

                ResponsiblePicker.SelectedIndex = i;
                ResponsiblePicker.SelectedItem = current;

                break;
            }
        }

        if (model.Decisor != null)
        {
            for (int i = 0; i < model.AvailableDecisors.Length; i++)
            {
                var current = model.AvailableDecisors[i];

                if (model.Decisor.Id != current.Id) continue;

                DecisorPicker.SelectedIndex = i;
                DecisorPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Plan de Compra";

    protected override async System.Threading.Tasks.Task<ProductionPlanDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ProductionPlanConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ProductionPlanInputModel
        {
            Id = System.Guid.NewGuid(),
            PlannedFor = concreteBindingContext.PlannedFor,
            Amount = concreteBindingContext.Amount,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ElaborationId = concreteBindingContext.Elaboration.Id,
            PlannerId = concreteBindingContext.AvailablePlanners[PlannerPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProductionPlanDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ProductionPlanConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ProductionPlanInputModel
        {
            Id = concreteBindingContext.Id,
            PlannedFor = concreteBindingContext.PlannedFor,
            Amount = concreteBindingContext.Amount,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ElaborationId = concreteBindingContext.Elaboration.Id,
            PlannerId = concreteBindingContext.AvailablePlanners[PlannerPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ElaborationChangeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ElaborationPickPage(ElaborationPickComplete_Callback)));
    }

    private void ElaborationPickComplete_Callback(ElaborationDisplayModel model)
    {
        ((Models.Page.Configuration.ProductionPlanConfigurationPageModel)BindingContext).Elaboration = model;

        hasChangesFlag = true;
    }
}