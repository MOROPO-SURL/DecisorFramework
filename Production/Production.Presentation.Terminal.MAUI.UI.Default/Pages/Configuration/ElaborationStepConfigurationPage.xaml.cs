using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationStepConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.ElaborationStepDisplayModel>
{
    public ElaborationStepConfigurationPage(System.Action<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> successAction, Models.Page.Configuration.ElaborationStepConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etapa de Elaboración";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> PerformCreationAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ElaborationStepDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            MinDecrease = concreteBindingContext.MinDecrease,
            MaxDecrease = concreteBindingContext.MaxDecrease,
            WorkPositions = concreteBindingContext.WorkPositions.ToArray()
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> PerformEditionAsync()
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext;

        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ElaborationStepDisplayModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            MinDecrease = concreteBindingContext.MinDecrease,
            MaxDecrease = concreteBindingContext.MaxDecrease,
            WorkPositions = concreteBindingContext.WorkPositions.ToArray()
        });
    }

    private void AddRoleButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var workPositionsAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.ElaborationStepWorkPositionBridgeConfigurationPageModel(null)
                {
                    AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new ElaborationStepWorkPositionBridgeConfigurationPage(RoleCreationSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void EditRoleButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var workPositionsAPIConnectClient = new HumanResources.Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.ElaborationStepWorkPositionBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel)
                {
                    AvailableWorkPositions = await workPositionsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new ElaborationStepWorkPositionBridgeConfigurationPage(RoleEditionSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void RoleRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este rol?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext).WorkPositions.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel));
        });
    }

    private void RoleCreationSuccess_Callback(Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel model)
    {
        ((Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext).WorkPositions.Add(model);

        hasChangesFlag = true;
    }

    private void RoleEditionSuccess_Callback(Interop.API.Common.Models.Bridge.ElaborationStepWorkPositionBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationStepConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.WorkPositions.First(item => item.WorkPosition.Id == model.WorkPosition.Id);

        var index = concreteBindingContext.WorkPositions.IndexOf(reference);

        concreteBindingContext.WorkPositions[index] = model;

        hasChangesFlag = true;
    }
}