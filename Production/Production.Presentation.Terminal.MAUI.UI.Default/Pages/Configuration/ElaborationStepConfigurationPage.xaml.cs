using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationStepConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ElaborationStepDisplayModel, Interop.API.Common.Models.Display.ElaborationStepDisplayModel, Models.Page.Configuration.ElaborationStepConfigurationPageModel>
{
    public ElaborationStepConfigurationPage(System.Action<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> successAction, Models.Page.Configuration.ElaborationStepConfigurationPageModel model) : base(successAction, model, new Validators.ElaborationStepConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Etapa de Técnica de Producción";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ElaborationStepDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            MinDecrease = ConcreteBindingContext.MinDecrease,
            MaxDecrease = ConcreteBindingContext.MaxDecrease,
            WorkPositions = [.. ConcreteBindingContext.WorkPositions]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ElaborationStepDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ElaborationStepDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            MinDecrease = ConcreteBindingContext.MinDecrease,
            MaxDecrease = ConcreteBindingContext.MaxDecrease,
            WorkPositions = [.. ConcreteBindingContext.WorkPositions]
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

    private void AddRoleButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

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
                    ConcreteBindingContext.IsBusy = false;

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
        ConcreteBindingContext.IsBusy = true;

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
                    ConcreteBindingContext.IsBusy = false;

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
        var reference = ConcreteBindingContext.WorkPositions.First(item => item.WorkPosition.Id == model.WorkPosition.Id);

        var index = ConcreteBindingContext.WorkPositions.IndexOf(reference);

        ConcreteBindingContext.WorkPositions[index] = model;

        hasChangesFlag = true;
    }
}