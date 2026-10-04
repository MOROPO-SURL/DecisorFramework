using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Connect.Clients;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages;

public partial class RecommendingDashboardPage : Framework.Caney.MVVM.Core.Pages.BindingContextedContentPage<Models.Page.RecommendingDashboardPageModel>
{
    private readonly IDispatcherTimer carouselTimer;

    private bool scrollToUp = true;

    public RecommendingDashboardPage() : base(new Models.Page.RecommendingDashboardPageModel
    {
        Images = [
            ImageSource.FromFile("recommenging_showcase_1.jpg"),
            ImageSource.FromFile("recommenging_showcase_2.jpg"),
            ImageSource.FromFile("recommenging_showcase_3.jpg"),
            ImageSource.FromFile("recommenging_showcase_4.jpg"),
            ImageSource.FromFile("recommenging_showcase_5.jpg")
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

    private void Refresh()
    {
        if (BindingContextPageModel.IsBusy) return;

        BindingContextPageModel.IsBusy = true;

        RecomendationReportsAPIConnectClient recomendationReportsAPIConnectClient = new(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        recomendationReportsAPIConnectClient.CountAsync().ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    BindingContextPageModel.ReportCount = task.Result;

                    BindingContextPageModel.IsBusy = false;
                });
            });
    }
}