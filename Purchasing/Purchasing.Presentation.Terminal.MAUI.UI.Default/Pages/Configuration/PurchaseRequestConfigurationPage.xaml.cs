using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseRequestConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Models.Page.Configuration.PurchaseRequestConfigurationPageModel>
{
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseRequestExpectedProductAdquisitionInputModel> editionExpectedProducttAdquisitions = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.PurchaseRequestExpectedProductAdquisitionInputModel> incomingExpectedProducttAdquisitions = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel> outgoingExpectedProducttAdquisitions = [];

    public PurchaseRequestConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel> successAction, Models.Page.Configuration.PurchaseRequestConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.PurchaseRequestConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Solicitud de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseRequestsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseRequestInputModel
        {
            Id = System.Guid.NewGuid(),
            Argument = ConcreteBindingContext.Argument,
            AuthorId = ConcreteBindingContext.Author.Id,
            Priority = ConcreteBindingContext.Priority,
            IncomingExpectedProducttAdquisitions = incomingExpectedProducttAdquisitions
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseRequestsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseRequestInputModel
        {
            Id = ConcreteBindingContext.Id,
            Argument = ConcreteBindingContext.Argument,
            AuthorId = ConcreteBindingContext.Author.Id,
            Priority = ConcreteBindingContext.Priority,
            EditionExpectedProducttAdquisitions = editionExpectedProducttAdquisitions,
            IncomingExpectedProducttAdquisitions = incomingExpectedProducttAdquisitions,
            OutgoingExpectedProducttAdquisitions = outgoingExpectedProducttAdquisitions
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

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void AddExpectedProductAdquisitioButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new PurchaseRequestExpectedProductAdquisitionConfigurationPage(ExpectedProductAdquisitioCreateSuccess_Callback, new Models.Page.Configuration.PurchaseRequestExpectedProductAdquisitionConfigurationPageModel(null)));
    }

    private void EditExpectedProductAdquisitioButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run((System.Func<System.Threading.Tasks.Task>)(async () =>
        {
            try
            {
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(httpClientProvider);
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel;

                var model = new Models.Page.Configuration.PurchaseRequestExpectedProductAdquisitionConfigurationPageModel(target)
                {
                    AvailableClassifications = [.. await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id })],
                    AvailableUnitMeasurements = [.. await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id)],
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseRequestExpectedProductAdquisitionConfigurationPage(ExpectedProductAdquisitioEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        }));
    }

    private void ExpectedProductAdquisitioRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este producto solictado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel;

                var handled = false;

                foreach (var item in incomingExpectedProducttAdquisitions)
                {
                    if (item.Id != target.Id) continue;

                    incomingExpectedProducttAdquisitions.Remove(incomingExpectedProducttAdquisitions.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionExpectedProducttAdquisitions)
                    {
                        if (item.Id != target.Id) continue;

                        editionExpectedProducttAdquisitions.Remove(editionExpectedProducttAdquisitions.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingExpectedProducttAdquisitions.Add(target);
                }

                ConcreteBindingContext.ExpectedProductAdquisitions.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AuthorPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void ExpectedProductAdquisitioCreateSuccess_Callback(Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel model)
    {
        if (ConcreteBindingContext.ExpectedProductAdquisitions.Any(_model => _model.Product.Id == model.Product.Id && ((_model.Classification == null && model.Classification == null) || _model.Classification.Id == model.Classification.Id)))
        {
            DisplayAlert("Aviso", "Ya se ha definido oferta para este producto y solo puede especificarse una vez.", "Aceptar");

            return;
        }

        incomingExpectedProducttAdquisitions.Add(new Interop.API.Common.Models.Input.PurchaseRequestExpectedProductAdquisitionInputModel
        {
            Id = model.Id,
            ProductId = model.Product.Id,
            ClassificationId = model.Classification?.Id,
            Amount = model.Amount,
            UnitMeasurementId = model.UnitMeasurement.Id,
        });

        ConcreteBindingContext.ExpectedProductAdquisitions.Add(model);

        hasChangesFlag = true;
    }

    private void ExpectedProductAdquisitioEditSuccess_Callback(Interop.API.Common.Models.Display.PurchaseRequestExpectedProductAdquisitionDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingExpectedProducttAdquisitions)
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
            foreach (var item in editionExpectedProducttAdquisitions)
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
            editionExpectedProducttAdquisitions.Add(new Interop.API.Common.Models.Input.PurchaseRequestExpectedProductAdquisitionInputModel
            {
                Id = model.Id,
                ProductId = model.Product.Id,
                ClassificationId = model.Classification?.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.ExpectedProductAdquisitions)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.ExpectedProductAdquisitions[index] = model;

            break;
        }

        hasChangesFlag = true;
    }
}