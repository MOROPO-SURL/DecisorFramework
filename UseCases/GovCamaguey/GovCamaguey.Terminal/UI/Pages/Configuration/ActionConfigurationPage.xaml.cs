using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class ActionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ActionInputModel, ActionInputModel, Models.Page.Configuration.ActionConfigurationPageModel>
{
    private readonly List<IndicatorInputModel> editionIndicators = [];
    private readonly List<IndicatorInputModel> incomingIndicators = [];
    private readonly List<IndicatorDisplayModel> outgoingIndicators = [];

    public ActionConfigurationPage(System.Action<ActionInputModel> successAction, Models.Page.Configuration.ActionConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    public ActionConfigurationPage(System.Action<ActionInputModel> successAction, Models.Page.Configuration.ActionConfigurationPageModel model, List<IndicatorInputModel> editionIndicators, List<IndicatorInputModel> incomingIndicators, List<IndicatorDisplayModel> outgoingIndicators) : this(successAction, model)
    {
        this.editionIndicators = editionIndicators;
        this.incomingIndicators = incomingIndicators;
        this.outgoingIndicators = outgoingIndicators;
    }

    protected override string EntityTypeName => "Acción";

    protected override System.Threading.Tasks.Task<ActionInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new ActionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            ResponsabilityOrganizations = [.. ConcreteBindingContext.ResponsabilityOrganizations],
            ParticipationOrganizations = [.. ConcreteBindingContext.ParticipationOrganizations],
            IncomingIndicators = incomingIndicators
        });
    }

    protected override System.Threading.Tasks.Task<ActionInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new ActionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            ResponsabilityOrganizations = [.. ConcreteBindingContext.ResponsabilityOrganizations],
            ParticipationOrganizations = [.. ConcreteBindingContext.ParticipationOrganizations],
            IncomingIndicators = incomingIndicators,
            EditionIndicators = editionIndicators,
            OutgoingIndicators = outgoingIndicators
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

    private void IndicatorAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.IndicatorConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetEnabledAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new IndicatorConfigurationPage(IndicatorCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void IndicatorEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as IndicatorDisplayModel;

        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.IndicatorConfigurationPageModel(target)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetEnabledAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new IndicatorConfigurationPage(IndicatorCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void IndicatorRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este indicador?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as IndicatorDisplayModel;

                var handled = false;

                foreach (var item in incomingIndicators)
                {
                    if (item.Id != target.Id) continue;

                    incomingIndicators.Remove(incomingIndicators.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionIndicators)
                    {
                        if (item.Id != target.Id) continue;

                        editionIndicators.Remove(editionIndicators.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingIndicators.Add(target);
                }

                ConcreteBindingContext.Indicators.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AddOrganizationParticipationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationPickPage(ParticipationOrganizationPickComplete_Callback)));
    }

    private void AddOrganizationResponsabilityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationPickPage(ResponsabilityOrganizationPickComplete_Callback)));
    }

    private void ParticipationOrganizationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este organismo participante?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.ParticipationOrganizations.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as OrganizationDisplayModel);

                hasChangesFlag = true;
            });
        });
    }

    private void ResponsabilityOrganizationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este organismo responsable?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.ResponsabilityOrganizations.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as OrganizationDisplayModel);

                hasChangesFlag = true;
            });
        });
    }

    private void IndicatorCreateSuccess_Callback(IndicatorDisplayModel model)
    {
        incomingIndicators.Add(new IndicatorInputModel
        {
            Id = model.Id,
            Priority = model.Priority,
            Name = model.Name,
            Description = model.Description,
            Amount = model.Amount,
            UnitMeasurementId = model.UnitMeasurement.Id
        });

        ConcreteBindingContext.Indicators.Add(model);

        hasChangesFlag = true;
    }

    private void IndicatorEditSuccess_Callback(IndicatorDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingIndicators)
        {
            if (item.Id != model.Id) continue;

            item.Priority = model.Priority;
            item.Name = model.Name;
            item.Description = model.Description;
            item.Amount = model.Amount;
            item.UnitMeasurementId = model.UnitMeasurement.Id;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionIndicators)
            {
                if (item.Id != model.Id) continue;

                item.Priority = model.Priority;
                item.Name = model.Name;
                item.Description = model.Description;
                item.Amount = model.Amount;
                item.UnitMeasurementId = model.UnitMeasurement.Id;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionIndicators.Add(new IndicatorInputModel
            {
                Id = model.Id,
                Priority = model.Priority,
                Name = model.Name,
                Description = model.Description,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Indicators)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Indicators[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void ParticipationOrganizationPickComplete_Callback(OrganizationDisplayModel model)
    {
        ConcreteBindingContext.ParticipationOrganizations.Add(model);

        hasChangesFlag = true;
    }

    private void ResponsabilityOrganizationPickComplete_Callback(OrganizationDisplayModel model)
    {
        ConcreteBindingContext.ResponsabilityOrganizations.Add(model);

        hasChangesFlag = true;
    }
}