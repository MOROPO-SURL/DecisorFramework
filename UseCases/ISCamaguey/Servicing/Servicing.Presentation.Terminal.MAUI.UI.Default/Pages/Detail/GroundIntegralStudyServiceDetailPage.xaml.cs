using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class GroundIntegralStudyServiceDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, int?> delegationAction;

    public GroundIntegralStudyServiceDetailPage(Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;

        OptionsStackLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel;

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

    private void ExportButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayActionSheet("Exportar", Contants.CommonConstants.CANCEL_OPTION, null, Contants.CommonConstants.TECH_PAPER_EXPORT_OPTION, Contants.CommonConstants.COST_PAPER_EXPORT_OPTION).ContinueWith(task =>
        {
            if (task.IsCanceled || task.Result == null || task.Result == Contants.CommonConstants.CANCEL_OPTION) return;

            Dispatcher.Dispatch(() => DisplayAlert("Aviso", "Funcionalidad en desarrollo.", "Aceptar"));
        });
    }

    private void DocumentDownloadButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        BusyIndicatorGrid.IsVisible = true;

        var httpClient = new System.Net.Http.HttpClient
        {
            Timeout = System.TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{httpClientHelperProvider.HttpClientHelper.ClientBaseAddress}media/documents/{model.Id}{model.Extension}").ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"{model.Name}{model.Extension}", new System.IO.MemoryStream(task.Result));

                    if (fileSaverResult.IsSuccessful)
                    {
                        await CommunityToolkit.Maui.Alerts.Toast.Make("Archivo descargado con éxito.").Show();
                    }
                    else
                    {
                        await CommunityToolkit.Maui.Alerts.Toast.Make("No fue posible salvar el archivo.").Show();
                    }
                }

                BusyIndicatorGrid.IsVisible = false;
            });
        });
    }
}