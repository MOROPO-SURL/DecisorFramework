using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientTrainingServiceExecutionDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, int?> delegationAction;

    public NaturalClientTrainingServiceExecutionDetailPage(Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;

        OptionButtonsLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            // null for Edit
            Dispatcher.Dispatch(() => delegationAction.Invoke(concreteBindingContext, null));
        });
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel;

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPopModalPageAsync().ContinueWith(_ =>
                {
                    // 0 for Delete
                    Dispatcher.Dispatch(() => delegationAction.Invoke(model, 0));
                });
            });
        });
    }

    private void DocumentDownloadButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        BusyIndicatorGrid.IsVisible = true;

        var httpClient = new System.Net.Http.HttpClient
        {
            Timeout = System.TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{httpClientHelperProvider.HttpClientHelper.ClientBaseAddress}media/documents/{model.Document.Id}{model.Document.Extension}").ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"{model.Document.Name}{model.Document.Extension}", new System.IO.MemoryStream(task.Result));

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
}