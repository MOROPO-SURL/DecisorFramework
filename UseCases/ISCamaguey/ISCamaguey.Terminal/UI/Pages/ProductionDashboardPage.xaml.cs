using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.Framework.Decisor.Domain.Interop.API.Connect.Clients;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Connect.Clients;
using MOROPO.Framework.Decisor.Production.Interop.API.Connect.Clients;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class ProductionDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.ProductionDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public ProductionDashboardPage() : base(new Models.Page.ProductionDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("production_showcase_1.jpg"),
            ImageSource.FromFile("production_showcase_2.jpg"),
            ImageSource.FromFile("production_showcase_3.jpg"),
            ImageSource.FromFile("production_showcase_4.jpg"),
            ImageSource.FromFile("production_showcase_5.jpg")
        ]
    })
    {
        InitializeComponent();

        carouselTimer = Dispatcher.CreateTimer();

        carouselTimer.Interval = System.TimeSpan.FromSeconds(5);

        carouselTimer.Tick += (sender, args) =>
        {
            if (BindingContext == null) return;

            Dispatcher.Dispatch(() =>
            {
                scrollToUp = MainCarouselView.Position switch
                {
                    0 => true,
                    4 => false,
                    _ => scrollToUp
                };

                var carouselNextIndex = scrollToUp ? MainCarouselView.Position + 1 : MainCarouselView.Position - 1;

                System.Diagnostics.Debug.WriteLine($"Scrolled from {MainCarouselView.Position} to {carouselNextIndex}");

                MainCarouselView.ScrollTo(carouselNextIndex);
            });
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        carouselTimer.Start();

        Refresh();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        carouselTimer.Stop();
    }

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        carouselTimer.Stop();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        Refresh();
    }

    private async void GoUnitMeasurementsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.UnitMeasurementsManagePage).Name}"));
    }

    private async void GoElaborationsManageSiteButton_Clicked(object sender, System.EventArgs args)
    {
        await Shell.Current.GoToAsync(new ShellNavigationState($"///{typeof(Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Manage.ElaborationsManagePage).Name}"));
    }

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        ProductionOrdersAPIConnectClient productionOrdersAPIConnectClient = new(httpClientHelperProvider);
        ProductionsAPIConnectClient productionsAPIConnectClient = new(httpClientHelperProvider);
        ProductionQualityChecksAPIConnectClient productionQualityChecksAPIConnectClient = new(httpClientHelperProvider);
        ElaborationsAPIConnectClient elaborationsAPIConnectClient = new(httpClientHelperProvider);
        ProductsAPIConnectClient productsAPIConnectClient = new(httpClientHelperProvider);
        FamiliesAPIConnectClient familiesAPIConnectClient = new(httpClientHelperProvider);
        UnitMeasurementsAPIConnectClient unitMeasurementsAPIConnectClient = new(httpClientHelperProvider);
        

        var productionOrderCountTask = productionOrdersAPIConnectClient.CountAsync();
        var productionCountTask = productionsAPIConnectClient.CountAsync();
        var productionQualityCheckCountTask = productionQualityChecksAPIConnectClient.CountAsync();
        var elaborationCountTask = elaborationsAPIConnectClient.CountAsync();
        var familyCountTask = familiesAPIConnectClient.CountAsync();
        var unitMeasurementCountTask = unitMeasurementsAPIConnectClient.CountAsync();

        System.Threading.Tasks.Task.WhenAll(productionOrderCountTask, productionCountTask, productionQualityCheckCountTask, elaborationCountTask, familyCountTask, unitMeasurementCountTask).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                BindingContextPageModel.OrderCount = productionOrderCountTask.Result;
                BindingContextPageModel.ProductCount = productionCountTask.Result;
                BindingContextPageModel.QualityCheckCount = productionQualityCheckCountTask.Result;
                BindingContextPageModel.ElaborationCount = elaborationCountTask.Result;
                BindingContextPageModel.FamilyCount = familyCountTask.Result;
                BindingContextPageModel.UnitMeasurementCount = unitMeasurementCountTask.Result;

                BindingContextPageModel.HasAnyUnitMeasurement = unitMeasurementCountTask.Result > 0;
                BindingContextPageModel.HasAnyElaboration = elaborationCountTask.Result > 0;

                BindingContextPageModel.IsModuleReady = BindingContextPageModel.HasAnyUnitMeasurement && BindingContextPageModel.HasAnyElaboration;

                BindingContextPageModel.IsBusy = false;
            });
        });
    }
}