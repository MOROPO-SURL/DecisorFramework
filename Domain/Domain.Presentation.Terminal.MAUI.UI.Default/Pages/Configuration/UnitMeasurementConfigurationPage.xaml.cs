using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class UnitMeasurementConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Models.Page.Configuration.UnitMeasurementConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> editionConvetions = [];
    private readonly List<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> incomingConvetions = [];
    private readonly List<Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel> outgoingConvetions = [];

    public UnitMeasurementConfigurationPage(System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> successAction, Models.Page.Configuration.UnitMeasurementConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.UnitMeasurementConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Unidad de Medida";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.UnitMeasurementInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Symbol = ConcreteBindingContext.Symbol,
            Priority = ConcreteBindingContext.Priority,
            IncomingConvertions = editionConvetions,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.UnitMeasurementInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Symbol = ConcreteBindingContext.Symbol,
            Priority = ConcreteBindingContext.Priority,
            IncomingConvertions = incomingConvetions,
            OutgoingConvertions = outgoingConvetions,
            EditionConvertions = editionConvetions,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ConvertionBridgeAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var unitMeasurements = new List<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>(await unitMeasurementsAPIConnectClient.GetAsync());

                unitMeasurements.RemoveAll(model => ConcreteBindingContext.Id == model.Id);

                var model = new Models.Page.Configuration.UnitMeasurementConvertionBridgeConfigurationPageModel(new Interop.API.Common.Models.Display.UnitMeasurementDisplayModel
                {
                    Id = ConcreteBindingContext.Id,
                    Name = ConcreteBindingContext.Name,
                    Symbol = ConcreteBindingContext.Symbol
                }, null)
                {
                    AvailableUnitMeasurements = unitMeasurements.ToArray()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new UnitMeasurementConvertionBridgeConfigurationPage(ConvertionBridgeCreateSuccess_Callback, model));
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

    private void ConvertionBridgeEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel;

        var model = new Models.Page.Configuration.UnitMeasurementConvertionBridgeConfigurationPageModel(new Interop.API.Common.Models.Display.UnitMeasurementDisplayModel
        { 
            Id = ConcreteBindingContext.Id, 
            Name = ConcreteBindingContext.Name,
            Symbol = ConcreteBindingContext.Symbol
        }, target)
        {
            AvailableUnitMeasurements = [target.Destination]
        };

        this.NavigationPushPageAsync(new UnitMeasurementConvertionBridgeConfigurationPage(ConvertionBridgeEditSuccess_Callback, model));
    }

    private void ConvertionBridgeRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta conversión?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel;

                var handled = false;

                foreach (var item in incomingConvetions)
                {
                    if (item.Destination.Id != target.Destination.Id) continue;

                    incomingConvetions.Remove(target);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionConvetions)
                    {
                        if (item.Destination.Id != target.Destination.Id) continue;

                        editionConvetions.Remove(target);

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingConvetions.Add(target);
                }

                ConcreteBindingContext.ConvertionBridges.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void ConvertionBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel model)
    {
        incomingConvetions.Add(model);

        ConcreteBindingContext.ConvertionBridges.Add(model);

        hasChangesFlag = true;
    }

    private void ConvertionBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.UnitMeasurementConvertionBridgeModel model)
    {
        var handled = false;

        foreach (var item in incomingConvetions)
        {
            if (item.Destination.Id != model.Destination.Id) continue;

            item.Convertion = model.Convertion;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionConvetions)
            {
                if (item.Destination.Id != model.Destination.Id) continue;

                item.Convertion = model.Convertion;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionConvetions.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.ConvertionBridges)
        {
            index++;

            if (item.Destination.Id != model.Destination.Id) continue;

            ConcreteBindingContext.ConvertionBridges[index] = model;

            break;
        }

        hasChangesFlag = true;
    }
}