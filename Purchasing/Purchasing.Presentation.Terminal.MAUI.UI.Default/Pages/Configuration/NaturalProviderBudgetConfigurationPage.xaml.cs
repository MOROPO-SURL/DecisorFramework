using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalProviderBudgetConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel, Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel>
{
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.NaturalProviderBudgetProductInputModel> editionBudgetProducts = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Input.NaturalProviderBudgetProductInputModel> incomingBudgetProducts = [];
    private readonly System.Collections.Generic.List<Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel> outgoingBudgetProducts = [];

    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    private bool documentEditionFlag;

    public NaturalProviderBudgetConfigurationPage(System.Action<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel> successCallbackAction, Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.NaturalProviderBudgetConfigurationPageModel> validator) : base(successCallbackAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Oferta de Proveedor Natural";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProviderBudgetsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalProviderBudgetInputModel
        {
            Id = System.Guid.NewGuid(),
            Number = ConcreteBindingContext.Number,
            Year = ConcreteBindingContext.Year,
            ProviderId = ConcreteBindingContext.Provider.Id,
            CommercialId = ConcreteBindingContext.Commercial.Id,
            Description = ConcreteBindingContext.Description,
            IncomingBudgetProducts = incomingBudgetProducts
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = ConcreteBindingContext.Document.Name,
                Description = ConcreteBindingContext.Document.Description,
                ContentData = new byte[stream.Length],
                ContentType = documentFilePickResult.ContentType
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderBudgetDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProviderBudgetsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalProviderBudgetInputModel
        {
            Id = ConcreteBindingContext.Id,
            Number = ConcreteBindingContext.Number,
            Year = ConcreteBindingContext.Year,
            ProviderId = ConcreteBindingContext.Provider.Id,
            CommercialId = ConcreteBindingContext.Commercial.Id,
            Description = ConcreteBindingContext.Description,
            EditionBudgetProducts = editionBudgetProducts,
            IncomingBudgetProducts = incomingBudgetProducts,
            OutgoingBudgetProducts = outgoingBudgetProducts
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = model.Document?.Id ?? default,
                Name = ConcreteBindingContext.Document.Name,
                Description = ConcreteBindingContext.Document.Description,
                ContentData = new byte[stream.Length],
                ContentType = documentFilePickResult.ContentType
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }
        else if (documentEditionFlag)
        {
            model.Document = new Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = ConcreteBindingContext.Document.Id,
                Name = ConcreteBindingContext.Document.Name,
                Description = ConcreteBindingContext.Document.Description
            };
        }

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

    private void ProviderPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.NaturalProviderPickPage(ProviderPickComplete_Callback)));
    }

    private void CommercialPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(CommercialPickComplete_Callback)));
    }

    private void AddBudgetProductButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var apiConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.NaturalProviderBudgetProductConfigurationPageModel(null)
                {
                    AvailableCurrencies = await apiConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new NaturalProviderBudgetProductConfigurationPage(BudgetProductCreateSuccess_Callback, model));
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

    private void EditBudgetProductButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(httpClientProvider);
                var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(httpClientProvider);
                var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientProvider);

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel;

                var model = new Models.Page.Configuration.NaturalProviderBudgetProductConfigurationPageModel(target)
                {
                    AvailableCurrencies = await currenciesAPIConnectClient.GetAsync(),
                    AvailableClassifications = [.. await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = target.Product.Id })],
                    AvailableUnitMeasurements = [.. await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id)],
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new NaturalProviderBudgetProductConfigurationPage(BudgetProductEditSuccess_Callback, model));
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

    private void BudgetProductRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este producto en oferta?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel;

                var handled = false;

                foreach (var item in incomingBudgetProducts)
                {
                    if (item.Id != target.Id) continue;

                    incomingBudgetProducts.Remove(editionBudgetProducts.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionBudgetProducts)
                    {
                        if (item.Id != target.Id) continue;

                        editionBudgetProducts.Remove(editionBudgetProducts.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingBudgetProducts.Add(target);
                }

                ConcreteBindingContext.BudgetProducts.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new System.Collections.Generic.Dictionary<Microsoft.Maui.Devices.DevicePlatform, System.Collections.Generic.IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, new[] { ".doc", ".docx", ".dot", ".pdf" } }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            documentFilePickResult = task.Result;

            using var stream = await documentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.Document = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(documentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(documentFilePickResult.FileName),
                    Length = lenght
                };
            });
        });
    }

    private void DocumentEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = new Core.Presentation.Terminal.MAUI.Models.Page.Configuration.DocumentConfigurationPageModel(ConcreteBindingContext.Document);

        this.NavigationPushPageAsync(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.DocumentConfigurationPage(DocumentEditSuccess_Callback, model));
    }

    private void ProviderPickComplete_Callback(Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel model)
    {
        ConcreteBindingContext.Provider = model;

        hasChangesFlag = true;
    }

    private void CommercialPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Commercial = model;

        hasChangesFlag = true;
    }

    private void BudgetProductCreateSuccess_Callback(Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel model)
    {
        if (ConcreteBindingContext.BudgetProducts.Any(_model => _model.Product.Id == model.Product.Id && ((_model.Classification == null && model.Classification == null) || _model.Classification.Id == model.Classification.Id)))
        {
            DisplayAlert("Aviso", "Ya se ha definido oferta para este producto y solo puede especificarse una vez.", "Aceptar");

            return;
        }

        incomingBudgetProducts.Add(new Interop.API.Common.Models.Input.NaturalProviderBudgetProductInputModel
        {
            Id = model.Id,
            ProductId = model.Product.Id,
            ClassificationId = model.Classification.Id,
            UnitPrice = model.UnitPrice,
            CurrentyId = model.Currency.Id,
            Amount = model.Amount,
            UnitMeasurementId = model.UnitMeasurement.Id,
        });

        ConcreteBindingContext.BudgetProducts.Add(model);

        hasChangesFlag = true;
    }

    private void BudgetProductEditSuccess_Callback(Interop.API.Common.Models.Display.NaturalProviderBudgetProductDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingBudgetProducts)
        {
            if (item.Id != model.Id) continue;

            item.ProductId = model.Product.Id;
            item.ClassificationId = model.Classification.Id;
            item.UnitPrice = model.UnitPrice;
            item.CurrentyId = model.Currency.Id;
            item.Amount = model.Amount;
            item.UnitMeasurementId = model.UnitMeasurement.Id;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionBudgetProducts)
            {
                if (item.Id != model.Id) continue;

                item.ProductId = model.Product.Id;
                item.ClassificationId = model.Classification.Id;
                item.UnitPrice = model.UnitPrice;
                item.CurrentyId = model.Currency.Id;
                item.Amount = model.Amount;
                item.UnitMeasurementId = model.UnitMeasurement.Id;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionBudgetProducts.Add(new Interop.API.Common.Models.Input.NaturalProviderBudgetProductInputModel
            {
                Id = model.Id,
                ProductId = model.Product.Id,
                ClassificationId = model.Classification.Id,
                UnitPrice = model.UnitPrice,
                CurrentyId = model.Currency.Id,
                Amount = model.Amount,
                UnitMeasurementId = model.UnitMeasurement.Id,
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.BudgetProducts)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.BudgetProducts[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void DocumentEditSuccess_Callback(Core.Interop.API.Common.Models.Display.DocumentDisplayModel model)
    {
        ConcreteBindingContext.Document = model;

        documentEditionFlag = true;
        hasChangesFlag = true;
    }
}