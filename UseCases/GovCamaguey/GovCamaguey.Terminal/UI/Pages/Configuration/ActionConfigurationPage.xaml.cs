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

    private readonly List<ActionMonthlyClosureInputModel> editionMonthlyClosures = [];
    private readonly List<ActionMonthlyClosureInputModel> incomingMonthlyClosures = [];
    private readonly List<ActionMonthlyClosureDisplayModel> outgoingMonthlyClosures = [];

    public ActionConfigurationPage(System.Action<ActionInputModel> successAction, Models.Page.Configuration.ActionConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    public ActionConfigurationPage(System.Action<ActionInputModel> successAction, Models.Page.Configuration.ActionConfigurationPageModel model, List<IndicatorInputModel> editionIndicators, List<IndicatorInputModel> incomingIndicators, List<IndicatorDisplayModel> outgoingIndicators, List<ActionMonthlyClosureInputModel> editionMonthlyClosures, List<ActionMonthlyClosureInputModel> incomingMonthlyClosures, List<ActionMonthlyClosureDisplayModel> outgoingMonthlyClosures) : this(successAction, model)
    {
        this.editionIndicators = editionIndicators;
        this.incomingIndicators = incomingIndicators;
        this.outgoingIndicators = outgoingIndicators;

        this.editionMonthlyClosures = editionMonthlyClosures;
        this.incomingMonthlyClosures = incomingMonthlyClosures;
        this.outgoingMonthlyClosures = outgoingMonthlyClosures;
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
            IncomingIndicators = incomingIndicators,
            IncomingMonthlyClosures = incomingMonthlyClosures
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
            OutgoingIndicators = outgoingIndicators,
            IncomingMonthlyClosures = incomingMonthlyClosures,
            EditionMonthlyClosures = editionMonthlyClosures,
            OutgoingMonthlyClosures = outgoingMonthlyClosures
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
                var model = incomingIndicators.FirstOrDefault(_model => _model.Id == target.Id) ?? editionIndicators.FirstOrDefault(_model => _model.Id == target.Id);

                model ??= new IndicatorInputModel
                {
                    Id = target.Id,
                    Name = target.Name,
                    Amount = target.Amount,
                    Priority = target.Priority,
                    Description = target.Description,
                    UnitMeasurementId = target.UnitMeasurement.Id
                };

                var unitMeasurementsAPIConnectClient = new Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var configurationModel = new Models.Page.Configuration.IndicatorConfigurationPageModel(model, target.MontlyPlans)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetEnabledAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new IndicatorConfigurationPage(IndicatorEditSuccess_Callback, configurationModel, model.EditionMontlyPlans, model.IncomingMontlyPlans, model.OutgoingMontlyPlans));
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

    private void MonthlyClosureAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ActionMonthlyClosureConfigurationPage(MonthlyClosureCreateSuccess_Callback, new Models.Page.Configuration.ActionMonthlyClosureConfigurationPageModel(null)));
    }

    private void MonthlyClosureEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ActionMonthlyClosureDisplayModel;

        this.NavigationPushPageAsync(new ActionMonthlyClosureConfigurationPage(MonthlyClosureEditSuccess_Callback, new Models.Page.Configuration.ActionMonthlyClosureConfigurationPageModel(new ActionMonthlyClosureInputModel { Id = target.Id, At = target.At })));
    }

    private void MonthlyClosureRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ActionMonthlyClosureDisplayModel;

                var handled = false;

                foreach (var item in incomingMonthlyClosures)
                {
                    if (item.Id != target.Id) continue;

                    incomingMonthlyClosures.Remove(incomingMonthlyClosures.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionMonthlyClosures)
                    {
                        if (item.Id != target.Id) continue;

                        editionMonthlyClosures.Remove(editionMonthlyClosures.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingMonthlyClosures.Add(target);
                }

                ConcreteBindingContext.MonthlyClosures.Remove(target);

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

    private void IndicatorCreateSuccess_Callback(IndicatorInputModel model)
    {
        incomingIndicators.Add(model);

        ConcreteBindingContext.Indicators.Add(new IndicatorDisplayModel
        {
            Id = model.Id,
            Priority = model.Priority,
            Name = model.Name,
            Description = model.Description,
            Amount = model.Amount,
            UnitMeasurement = new UnitMeasurementDisplayModel { Id = model.UnitMeasurementId }
        });

        hasChangesFlag = true;
    }

    private void IndicatorEditSuccess_Callback(IndicatorInputModel model)
    {
        var handled = false;

        foreach (var item in incomingIndicators)
        {
            if (item.Id != model.Id) continue;

            item.Priority = model.Priority;
            item.Name = model.Name;
            item.Description = model.Description;
            item.Amount = model.Amount;
            item.UnitMeasurementId = model.UnitMeasurementId;

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
                item.UnitMeasurementId = model.UnitMeasurementId;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionIndicators.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Indicators)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Indicators[index] = new IndicatorDisplayModel
            {
                Id = model.Id,
                Priority = model.Priority,
                Name = model.Name,
                Description = model.Description,
                Amount = model.Amount,
                UnitMeasurement = new UnitMeasurementDisplayModel { Id = model.UnitMeasurementId }
            };

            break;
        }

        hasChangesFlag = true;
    }

    private void MonthlyClosureCreateSuccess_Callback(ActionMonthlyClosureInputModel model)
    {
        incomingMonthlyClosures.Add(model);

        ConcreteBindingContext.MonthlyClosures.Add(new ActionMonthlyClosureDisplayModel
        {
            Id = model.Id,
            At = model.At
        });

        hasChangesFlag = true;
    }

    private void MonthlyClosureEditSuccess_Callback(ActionMonthlyClosureInputModel model)
    {
        var handled = false;

        foreach (var item in incomingMonthlyClosures)
        {
            if (item.Id != model.Id) continue;

            item.At = model.At;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionMonthlyClosures)
            {
                if (item.Id != model.Id) continue;

                item.At = model.At;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionMonthlyClosures.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.MonthlyClosures)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.MonthlyClosures[index] = new ActionMonthlyClosureDisplayModel
            {
                Id = model.Id,
                At = model.At
            };

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