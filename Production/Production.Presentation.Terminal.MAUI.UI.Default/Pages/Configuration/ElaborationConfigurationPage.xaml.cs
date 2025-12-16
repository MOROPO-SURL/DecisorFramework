using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ElaborationDisplayModel, ElaborationDisplayModel, Models.Page.Configuration.ElaborationConfigurationPageModel>
{
    public ElaborationConfigurationPage(System.Action<ElaborationDisplayModel> successAction, Models.Page.Configuration.ElaborationConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ElaborationConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Classification != null)
        {
            for (int i = 0; i < model.AvailableClassifications.Length; i++)
            {
                var current = model.AvailableClassifications[i];

                if (model.Classification.Id != current.Id) continue;

                ClassificationPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Técnica de Producción";

    protected override async System.Threading.Tasks.Task<ElaborationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ElaborationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ElaborationInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            ProductId = ConcreteBindingContext.Product.Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            MinPerformanceCoefficient = ConcreteBindingContext.MinPerformanceCoefficient,
            MaxPerformanceCoefficient = ConcreteBindingContext.MaxPerformanceCoefficient,
            InputProductBridges = [.. ConcreteBindingContext.InputProductBridges],
            OutputProductBridges = [.. ConcreteBindingContext.OutputProductBridges],
            Steps = [.. ConcreteBindingContext.Steps]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ElaborationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ElaborationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ElaborationInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            ProductId = ConcreteBindingContext.Product.Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            MinPerformanceCoefficient = ConcreteBindingContext.MinPerformanceCoefficient,
            MaxPerformanceCoefficient = ConcreteBindingContext.MaxPerformanceCoefficient,
            InputProductBridges = [.. ConcreteBindingContext.InputProductBridges],
            OutputProductBridges = [.. ConcreteBindingContext.OutputProductBridges],
            Steps = [.. ConcreteBindingContext.Steps]
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ProductPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(ProductPickComplete_Callback)));
    }

    private void AddInputProductButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(InputElaborationProductBridgeCreateSuccess_Callback, new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(null)));
    }

    private void AddOutputProductButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(OutputElaborationProductBridgeCreateSuccess_Callback, new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(null)));
    }

    private void AddStepButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ElaborationStepConfigurationPage(StepCreateSuccess_Callback, new Models.Page.Configuration.ElaborationStepConfigurationPageModel(null)));
    }

    private void EditInputProductButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel;

        if (target.Classification == null)
        {
            this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(InputElaborationProductBridgeEditSuccess_Callback, new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(target)));
        }
        else
        {
            ConcreteBindingContext.IsBusy = true;

            var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id }).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        var model = new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(target)
                        {
                            AvailableClassifications = [.. task.Result]
                        };

                        this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(InputElaborationProductBridgeEditSuccess_Callback, model));
                    }
                    else
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }

                    ConcreteBindingContext.IsBusy = false;
                });
            });
        }
    }

    private void EditOutputProductButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel;

        if (target.Classification == null)
        {
            this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(OutputElaborationProductBridgeEditSuccess_Callback, new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(target)));
        }
        else
        {
            ConcreteBindingContext.IsBusy = true;

            var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

            classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id }).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        var model = new Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel(target)
                        {
                            AvailableClassifications = [.. task.Result]
                        };

                        this.NavigationPushPageAsync(new CommonElaborationProductBridgeConfigurationPage(OutputElaborationProductBridgeEditSuccess_Callback, model));
                    }
                    else
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }

                    ConcreteBindingContext.IsBusy = false;
                });
            });
        }
    }

    private void EditStepButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ElaborationStepConfigurationPage(StepEditSuccess_Callback, new Models.Page.Configuration.ElaborationStepConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ElaborationStepDisplayModel)));
    }

    private void InputProductRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este insumo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.InputProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel));
        });
    }

    private void OutputProductRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este sub-producto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.OutputProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel));
        });
    }

    private void RemoveStepButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar esta etapa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.Steps.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ElaborationStepDisplayModel));
        });
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ConcreteBindingContext.Product = model;

        ConcreteBindingContext.IsBusy = true;

        var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = ConcreteBindingContext.Product.Id }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    HandleException(task.Exception);
                }
                else
                {
                    ConcreteBindingContext.AvailableClassifications = task.Result;
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void InputElaborationProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel model)
    {
        ConcreteBindingContext.InputProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void OutputElaborationProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel model)
    {
        ConcreteBindingContext.OutputProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void StepCreateSuccess_Callback(ElaborationStepDisplayModel model)
    {
        var _models = ConcreteBindingContext.Steps.ToList();

        _models.Add(model);

        _models = [.. _models.OrderBy(_model => _model.Priority)];

        ConcreteBindingContext.Steps.Clear();

        foreach (var _model in _models)
        {
            ConcreteBindingContext.Steps.Add(_model);
        }

        hasChangesFlag = true;
    }

    private void InputElaborationProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel model)
    {
        var reference = ConcreteBindingContext.InputProductBridges.First(item => item.Key == model.Key);

        var index = ConcreteBindingContext.InputProductBridges.IndexOf(reference);

        ConcreteBindingContext.InputProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void OutputElaborationProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel model)
    {
        var reference = ConcreteBindingContext.OutputProductBridges.First(item => item.Key == model.Key);

        var index = ConcreteBindingContext.OutputProductBridges.IndexOf(reference);

        ConcreteBindingContext.OutputProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void StepEditSuccess_Callback(ElaborationStepDisplayModel model)
    {
        var _models = new System.Collections.Generic.List<ElaborationStepDisplayModel>();

        foreach (var _model in ConcreteBindingContext.Steps)
        {
            if (_model.Id == model.Id)
            {
                _models.Add(model);

                continue;
            }

            _models.Add(_model);
        }

        _models = [.. _models.OrderBy(_model => _model.Priority)];

        ConcreteBindingContext.Steps.Clear();

        foreach (var _model in _models)
        {
            ConcreteBindingContext.Steps.Add(_model);
        }

        hasChangesFlag = true;
    }
}