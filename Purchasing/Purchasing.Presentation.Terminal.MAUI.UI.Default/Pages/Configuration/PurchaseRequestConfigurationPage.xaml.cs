using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseRequestConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Interop.API.Common.Models.Display.PurchaseRequestDisplayModel, Models.Page.Configuration.PurchaseRequestConfigurationPageModel>
{
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
            ProductBridges = [.. ConcreteBindingContext.ProductBridges]
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
            ProductBridges = [.. ConcreteBindingContext.ProductBridges]
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

    private void AddProductBridgeButton_Clicked(object sender, System.EventArgs e)
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

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Producto", ProductBridgeCreateSuccess_Callback, model));
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

    private void EditProductBridgeButton_Clicked(object sender, System.EventArgs e)
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

                    this.NavigationPushPageAsync(new PurchaseCommonProductBridgeConfigurationPage("Producto", ProductBridgeEditSuccess_Callback, model));
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

    private void ProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este producto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchaseRequestConfigurationPageModel)BindingContext).ProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel));
        });
    }

    private void AuthorPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void ProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        ((Models.Page.Configuration.PurchaseRequestConfigurationPageModel)BindingContext).ProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void ProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseCommonProductBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseRequestConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.ProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = concreteBindingContext.ProductBridges.IndexOf(reference);

        concreteBindingContext.ProductBridges[index] = model;

        hasChangesFlag = true;
    }
}