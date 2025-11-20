using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseOrderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Models.Page.Configuration.PurchaseOrderConfigurationPageModel>
{
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseOrderExpectedProductResultInputModel> editionExpectedProductResults = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseOrderExpectedProductResultInputModel> incomingExpectedProductResults = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel> outgoingExpectedProductResults = [];

    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseOrderPlannedProductSpentInputModel> editionPlannedProductSpents = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseOrderPlannedProductSpentInputModel> incomingPlannedProductSpents = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel> outgoingPlannedProductSpents = [];

    public PurchaseOrderConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel> successAction, Models.Page.Configuration.PurchaseOrderConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.PurchaseOrderConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Zone != null)
        {
            for (int i = 0; i < model.AvailableZones.Length; i++)
            {
                var current = model.AvailableZones[i];

                if (model.Zone.Id != current.Id) continue;

                ZonePicker.SelectedIndex = i;

                break;
            }
        }

        if (model.AdvanceRequiredCurrency != null)
        {
            for (int i = 0; i < model.AvailableCurrencies.Length; i++)
            {
                var current = model.AvailableCurrencies[i];

                if (model.Zone.Id != current.Id) continue;

                CurrencyPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Orden de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseOrderInputModel
        {
            Id = System.Guid.NewGuid(),
            PlannedFor = ConcreteBindingContext.PlannedFor,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            RequestId = ConcreteBindingContext.Request.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            ZoneId = ConcreteBindingContext.Zone.Id,
            AdvanceRequired = ConcreteBindingContext.HasAdvanceRequired ? ConcreteBindingContext.AdvanceRequired : null,
            AdvanceRequiredCurrencyId = ConcreteBindingContext.HasAdvanceRequired ? ConcreteBindingContext.AdvanceRequiredCurrency.Id : null,
            LegalProviderBudgets = [.. ConcreteBindingContext.LegalProviderBudgets],
            NaturalProviderBudgets = [.. ConcreteBindingContext.NaturalProviderBudgets],
            IncomingExpectedProductResults = incomingExpectedProductResults,
            IncomingPlannedProductSpents = incomingPlannedProductSpents
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseOrderInputModel
        {
            Id = ConcreteBindingContext.Id,
            PlannedFor = ConcreteBindingContext.PlannedFor,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            RequestId = ConcreteBindingContext.Request.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            ZoneId = ConcreteBindingContext.Zone.Id,
            AdvanceRequired = ConcreteBindingContext.HasAdvanceRequired ? ConcreteBindingContext.AdvanceRequired : null,
            AdvanceRequiredCurrencyId = ConcreteBindingContext.HasAdvanceRequired ? ConcreteBindingContext.AdvanceRequiredCurrency.Id : null,
            LegalProviderBudgets = [.. ConcreteBindingContext.LegalProviderBudgets],
            NaturalProviderBudgets = [.. ConcreteBindingContext.NaturalProviderBudgets],
            EditionExpectedProductResults = editionExpectedProductResults,
            IncomingExpectedProductResults = incomingExpectedProductResults,
            OutgoingExpectedProductResults = outgoingExpectedProductResults,
            EditionPlannedProductSpents = editionPlannedProductSpents,
            IncomingPlannedProductSpents = incomingPlannedProductSpents,
            OutgoingPlannedProductSpents = outgoingPlannedProductSpents
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

    private void RequestPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PurchaseRequestPickPage(RequestPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void ResponsiblePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(ResponsiblePickComplete_Callback)));
    }

    private void AddLegalProviderBudgetButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.LegalProviderBudgetPickPage(LegalProviderBudgetPickComplete_Callback)));
    }

    private void AddNaturalProviderBudgetButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalProviderBudgetPickPage(NaturalProviderBudgetPickComplete_Callback)));
    }

    private void DetailLegalProviderBudgetButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Detail.LegalProviderBudgetDetailPage((((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel), null));
    }

    private void DetailNaturalProviderBudgetButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Detail.NaturalProviderBudgetDetailPage((((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel), null));
    }

    private void AddPlannedProductSpentButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new PurchaseOrderPlannedProductSpentConfigurationPage(PlannedProductSpentCreateSuccess_Callback, new Models.Page.Configuration.PurchaseOrderPlannedProductSpentConfigurationPageModel(null)));
    }

    private void ResetExpectedProductResultsButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea re-establecer a las valores de la solicitud los productos esperados?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                while (ConcreteBindingContext.ExpectedProductResults.Count > 0)
                {
                    PerformExpectedProductResultRemotion(ConcreteBindingContext.ExpectedProductResults.First());
                }

                foreach (var model in ConcreteBindingContext.Request.ExpectedProductAdquisitions)
                {
                    ExpectedProductResultCreateSuccess_Callback(new Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel
                    {
                        Id = System.Guid.NewGuid(),
                        Product = model.Product,
                        Classification = model.Classification,
                        Amount = model.Amount,
                        UnitMeasurement = model.UnitMeasurement
                    });
                }
            });
        });
    }

    private void AddExpectedProductResultButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new PurchaseOrderExpectedProductResultConfigurationPage(ExpectedProductResultCreateSuccess_Callback, new Models.Page.Configuration.PurchaseOrderExpectedProductResultConfigurationPageModel(null)));
    }

    private void EditPlannedProductSpentButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(httpClientProvider);
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel;

                var model = new Models.Page.Configuration.PurchaseOrderPlannedProductSpentConfigurationPageModel(target)
                {
                    AvailableClassifications = [.. await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id })],
                    AvailableUnitMeasurements = [.. await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id)],
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseOrderPlannedProductSpentConfigurationPage(PlannedProductSpentEditSuccess_Callback, model));
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

    private void EditExpectedProductResultButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(httpClientProvider);
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel;

                var model = new Models.Page.Configuration.PurchaseOrderExpectedProductResultConfigurationPageModel(target)
                {
                    AvailableClassifications = [.. await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id })],
                    AvailableUnitMeasurements = [.. await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id)],
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseOrderExpectedProductResultConfigurationPage(ExpectedProductResultEditSuccess_Callback, model));
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

    private void SpentProductBridgeRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este insumo asignado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel;

                var handled = false;

                foreach (var item in incomingPlannedProductSpents)
                {
                    if (item.Id != target.Id) continue;

                    incomingPlannedProductSpents.Remove(incomingPlannedProductSpents.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionPlannedProductSpents)
                    {
                        if (item.Id != target.Id) continue;

                        editionPlannedProductSpents.Remove(editionPlannedProductSpents.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingPlannedProductSpents.Add(target);
                }

                ConcreteBindingContext.PlannedProductSpents.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ExpectedProductResultRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este producto esperado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel;

                PerformExpectedProductResultRemotion(target);
            });
        });
    }

    private void LegalProviderBudgetRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta oferta de proveedor legal del listado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.LegalProviderBudgets.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel));
        });
    }

    private void NaturalProviderBudgetRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta oferta de proveedor natural del listado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.NaturalProviderBudgets.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel));
        });
    }

    private void LegalProviderBudgetPickComplete_Callback(Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel model)
    {
        ConcreteBindingContext.LegalProviderBudgets.Add(model);

        hasChangesFlag = true;
    }

    private void NaturalProviderBudgetPickComplete_Callback(Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel model)
    {
        ConcreteBindingContext.NaturalProviderBudgets.Add(model);

        hasChangesFlag = true;
    }

    private void RequestPickComplete_Callback(Interop.API.Common.Models.Display.PurchaseRequestDisplayModel model)
    {
        ConcreteBindingContext.Request = model;

        if (ConcreteBindingContext.ExpectedProductResults.Count > 0) return;

        foreach (var _model in ConcreteBindingContext.Request.ExpectedProductAdquisitions)
        {
            ExpectedProductResultCreateSuccess_Callback(new Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel
            {
                Id = System.Guid.NewGuid(),
                Product = _model.Product,
                Classification = _model.Classification,
                Amount = _model.Amount,
                UnitMeasurement = _model.UnitMeasurement
            });
        }
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }

    private void ResponsiblePickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;
    }

    private void ExpectedProductResultCreateSuccess_Callback(Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel model)
    {
        if (ConcreteBindingContext.ExpectedProductResults.Any(_model => _model.Product.Id == model.Product.Id && ((_model.Classification == null && model.Classification == null) || _model.Classification.Id == model.Classification.Id)))
        {
            DisplayAlert("Aviso", "Ya se ha definido elemento para este producto y solo puede especificarse una vez.", "Aceptar");

            return;
        }

        incomingExpectedProductResults.Add(new Interop.API.Common.Models.Input.PurchaseOrderExpectedProductResultInputModel
        {
            Id = model.Id,
            ProductId = model.Product.Id,
            ClassificationId = model.Classification?.Id,
            Amount = model.Amount,
            UnitMeasurementId = model.UnitMeasurement.Id,
        });

        ConcreteBindingContext.ExpectedProductResults.Add(model);

        hasChangesFlag = true;
    }

    private void ExpectedProductResultEditSuccess_Callback(Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingExpectedProductResults)
        {
            if (item.Id != model.Id) continue;

            item.ProductId = model.Product.Id;
            item.ClassificationId = model.Classification?.Id;
            item.Amount = model.Amount;
            item.UnitMeasurementId = model.UnitMeasurement.Id;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionExpectedProductResults)
            {
                if (item.Id != model.Id) continue;

                item.ProductId = model.Product.Id;
                item.ClassificationId = model.Classification?.Id;
                item.Amount = model.Amount;
                item.UnitMeasurementId = model.UnitMeasurement.Id;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionExpectedProductResults.Add(new Interop.API.Common.Models.Input.PurchaseOrderExpectedProductResultInputModel
            {
                Id = model.Id,
                ProductId = model.Product.Id,
                ClassificationId = model.Classification?.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.ExpectedProductResults)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.ExpectedProductResults[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void PlannedProductSpentCreateSuccess_Callback(Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel model)
    {
        if (ConcreteBindingContext.PlannedProductSpents.Any(_model => _model.Product.Id == model.Product.Id && ((_model.Classification == null && model.Classification == null) || _model.Classification.Id == model.Classification.Id)))
        {
            DisplayAlert("Aviso", "Ya se ha definido elemento para este producto y solo puede especificarse una vez.", "Aceptar");

            return;
        }

        incomingPlannedProductSpents.Add(new Interop.API.Common.Models.Input.PurchaseOrderPlannedProductSpentInputModel
        {
            Id = model.Id,
            ProductId = model.Product.Id,
            ClassificationId = model.Classification?.Id,
            Amount = model.Amount,
            UnitMeasurementId = model.UnitMeasurement.Id,
        });

        ConcreteBindingContext.PlannedProductSpents.Add(model);

        hasChangesFlag = true;
    }

    private void PlannedProductSpentEditSuccess_Callback(Interop.API.Common.Models.Display.PurchaseOrderPlannedProductSpentDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingPlannedProductSpents)
        {
            if (item.Id != model.Id) continue;

            item.ProductId = model.Product.Id;
            item.ClassificationId = model.Classification?.Id;
            item.Amount = model.Amount;
            item.UnitMeasurementId = model.UnitMeasurement.Id;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionPlannedProductSpents)
            {
                if (item.Id != model.Id) continue;

                item.ProductId = model.Product.Id;
                item.ClassificationId = model.Classification?.Id;
                item.Amount = model.Amount;
                item.UnitMeasurementId = model.UnitMeasurement.Id;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionPlannedProductSpents.Add(new Interop.API.Common.Models.Input.PurchaseOrderPlannedProductSpentInputModel
            {
                Id = model.Id,
                ProductId = model.Product.Id,
                ClassificationId = model.Classification?.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.PlannedProductSpents)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.PlannedProductSpents[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void PerformExpectedProductResultRemotion(Interop.API.Common.Models.Display.PurchaseOrderExpectedProductResultDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingExpectedProductResults)
        {
            if (item.Id != model.Id) continue;

            incomingExpectedProductResults.Remove(incomingExpectedProductResults.First(model => model.Id == model.Id));

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionExpectedProductResults)
            {
                if (item.Id != model.Id) continue;

                editionExpectedProductResults.Remove(editionExpectedProductResults.First(model => model.Id == model.Id));

                break;
            }
        }

        if (!handled)
        {
            outgoingExpectedProductResults.Add(model);
        }

        ConcreteBindingContext.ExpectedProductResults.Remove(model);

        hasChangesFlag = true;
    }
}