using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseOrderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Interop.API.Common.Models.Display.PurchaseOrderDisplayModel, Models.Page.Configuration.PurchaseOrderConfigurationPageModel>
{
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
            ResultProductBridges = [.. ConcreteBindingContext.ResultProductBridges],
            SpentProductBridges = [.. ConcreteBindingContext.SpentProductBridges]
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
            ResultProductBridges = [.. ConcreteBindingContext.ResultProductBridges],
            SpentProductBridges = [.. ConcreteBindingContext.SpentProductBridges]
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

    private void AddSpentProductBridgeButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Insumo asignado", SpentProductBridgeCreateSuccess_Callback, model));
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

    private void ResetResultProductBridgesButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea re-establecer a las valores de la solicitud los productos a adquirir?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.ResultProductBridges.Clear();

                foreach (var model in ConcreteBindingContext.Request.ProductBridges)
                {
                    ConcreteBindingContext.ResultProductBridges.Add(model);
                }
            });
        });
    }

    private void AddResultProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel(null)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Producto a adquirir", ResultProductBridgeCreateSuccess_Callback, model));
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

    private void EditSpentProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Insumo asignado", SpentProductBridgeEditSuccess_Callback, model));
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

    private void EditResultProductBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseCommonProductBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Producto a adquirir", ResultProductBridgeEditSuccess_Callback, model));
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

    private void SpentProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este insumo asignado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.SpentProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel));
        });
    }

    private void ResultProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este producto a adquirir?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ConcreteBindingContext.ResultProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel));
        });
    }

    private void LegalProviderBudgetRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta oferta de proveedor legal del listado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ConcreteBindingContext.LegalProviderBudgets.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.LegalProviderBudgetDisplayModel));
        });
    }

    private void NaturalProviderBudgetRemoveButton_Clicked(object sender, System.EventArgs e)
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

    private void SpentProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        ConcreteBindingContext.SpentProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void SpentProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        var reference = ConcreteBindingContext.SpentProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = ConcreteBindingContext.SpentProductBridges.IndexOf(reference);

        ConcreteBindingContext.SpentProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void ResultProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        ConcreteBindingContext.ResultProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void ResultProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        var reference = ConcreteBindingContext.ResultProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = ConcreteBindingContext.ResultProductBridges.IndexOf(reference);

        ConcreteBindingContext.ResultProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void RequestPickComplete_Callback(Interop.API.Common.Models.Display.PurchaseRequestDisplayModel model)
    {
        ConcreteBindingContext.Request = model;

        if (ConcreteBindingContext.ResultProductBridges.Count > 0) return;

        foreach (var _model in ConcreteBindingContext.Request.ProductBridges)
        {
            ConcreteBindingContext.ResultProductBridges.Add(_model);
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
}