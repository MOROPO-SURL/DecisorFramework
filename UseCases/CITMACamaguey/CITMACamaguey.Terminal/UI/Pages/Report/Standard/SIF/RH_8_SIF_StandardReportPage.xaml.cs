using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.CITMACamaguey.Decisor.Terminal.UI.Pages.Report.Standard.SIF;

public partial class RH_8_SIF_StandardReportPage : Microsoft.Maui.Controls.ContentPage
{
	public RH_8_SIF_StandardReportPage()
	{
		InitializeComponent();

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        MainWebView.Source = new System.Uri($"{httpClientHelperProvider.HttpClientHelper.ClientBaseAddress}report/standard/sif/rh_08/web");

    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (BusyIndicatorGrid.IsVisible) return;

        MainWebView.Reload();
    }

    private void DownloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (BusyIndicatorGrid.IsVisible) return;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        BusyIndicatorGrid.IsVisible = true;

        var httpClient = new System.Net.Http.HttpClient
        {
            Timeout = System.TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{httpClientHelperProvider.HttpClientHelper.ClientBaseAddress}report/standard/sif/rh_08/print").ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"SIF-RH-08_{System.DateTime.Now.Ticks}.pdf", new System.IO.MemoryStream(task.Result));

                    if (fileSaverResult.IsSuccessful)
                    {
                        this.PresentToastNotification(Framework.Decisor.Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Archivo descargado con éxito.");
                    }
                    else if (fileSaverResult.FilePath != null)
                    {
                        this.PresentToastNotification(Framework.Decisor.Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Error, "No fue posible salvar el archivo.");
                    }
                }

                BusyIndicatorGrid.IsVisible = false;
            });
        });
    }

    private void PrintToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (BusyIndicatorGrid.IsVisible) return;

        
    }

    private void MainWebView_Navigating(object sender, Microsoft.Maui.Controls.WebNavigatingEventArgs e)
    {
        BusyIndicatorGrid.IsVisible = true;
    }

    private void MainWebView_Navigated(object sender, Microsoft.Maui.Controls.WebNavigatedEventArgs e)
    {
        BusyIndicatorGrid.IsVisible = false;
    }
}