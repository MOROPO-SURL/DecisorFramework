using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalProviderBudgetProductConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel, Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel, Models.Page.Configuration.LegalProviderBudgetProductConfigurationPageModel>
{
	public LegalProviderBudgetProductConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel> successCallbackAction, Models.Page.Configuration.LegalProviderBudgetProductConfigurationPageModel model) : base(successCallbackAction, model, new Validators.LegalProviderBugetProductConfigurationValidator())
	{
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Count; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Currency != null)
        {
            for (int i = 0; i < model.AvailableCurrencies.Length; i++)
            {
                var current = model.AvailableCurrencies[i];

                if (model.Currency.Id != current.Id) continue;

                CurrencyPicker.SelectedIndex = i;

                break;
            }
        }

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

    protected override bool IsNotificationRequired => false;

    protected override string EntityTypeName => "Oferta de Producto";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Product = ConcreteBindingContext.Product,
            Classification = ConcreteBindingContext.Classification,
            UnitPrice = ConcreteBindingContext.UnitPrice,
            Currency = ConcreteBindingContext.Currency,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurement = ConcreteBindingContext.UnitMeasurement
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.LegalProviderBudgetProductDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Product = ConcreteBindingContext.Product,
            Classification = ConcreteBindingContext.Classification,
            UnitPrice = ConcreteBindingContext.UnitPrice,
            Currency = ConcreteBindingContext.Currency,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurement = ConcreteBindingContext.UnitMeasurement
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ProductPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(ProductPickComplete_Callback)));
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ConcreteBindingContext.Product = model;

        ConcreteBindingContext.AvailableUnitMeasurements.Clear();

        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(httpClientProvider);
            var classificationsAPIConnectClient = new Inventory.Interop.API.Connect.Clients.ClassificationsAPIConnectClient(httpClientProvider);

            try
            {
                var unitMeasurements = await unitMeasurementsAPIConnectClient.GetReleatedsAsync(ConcreteBindingContext.Product.DefaultUnitMeasurement.Id);
                var classifications = await classificationsAPIConnectClient.FilterAsync(new Inventory.Interop.API.Common.Models.Filter.ClassificationFilterModel { ProductId = ConcreteBindingContext.Product.Id });

                Dispatcher.Dispatch(() =>
                {
                    foreach (var unitMeasurement in unitMeasurements)
                    {
                        ConcreteBindingContext.AvailableUnitMeasurements.Add(unitMeasurement);
                    }

                    ConcreteBindingContext.AvailableClassifications = classifications;

                    ConcreteBindingContext.IsBusy = false;
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    HandleException(exception);

                    ConcreteBindingContext.IsBusy = false;
                });
            }
        });
    }
}