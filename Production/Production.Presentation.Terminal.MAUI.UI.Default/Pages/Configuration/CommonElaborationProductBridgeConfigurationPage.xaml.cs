using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CommonElaborationProductBridgeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel, Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel, Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel>
{
    public CommonElaborationProductBridgeConfigurationPage(System.Action<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel> successAction, Models.Page.Configuration.CommonElaborationProductBridgeConfigurationPageModel model) : base(successAction, model, new Validators.CommonElaborationProductBridgeConfigurationValidator())
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

    protected override string EntityTypeName => "Insumo";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel
        {
            Product = ConcreteBindingContext.Product,
            Classification = ConcreteBindingContext.Classification,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurement = ConcreteBindingContext.UnitMeasurement
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Bridge.CommonElaborationProductBridgeModel
        {
            Product = ConcreteBindingContext.Product,
            Classification = ConcreteBindingContext.Classification,
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

    private void ProductPickButton_Clicked(object sender, System.EventArgs e)
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