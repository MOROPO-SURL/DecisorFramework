using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientServicingContractDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, int?> delegationAction;

    public NaturalClientServicingContractDetailPage(Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;

        OptionsButtonLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel;

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

/* Cambio no fusionado mediante combinación del proyecto 'Servicing.Presentation.Terminal.MAUI.UI.Default (net8.0-android)'
Antes:
        DisplayActionSheet("Exportar", Contants.CommonConstants.CANCEL_OPTION, null, Contants.CommonConstants.TECH_PAPER_EXPORT_OPTION, Contants.CommonConstants.COST_PAPER_EXPORT_OPTION).ContinueWith(task =>
Después:
        DisplayActionSheet("Exportar", CommonConstants.CANCEL_OPTION, null, CommonConstants.TECH_PAPER_EXPORT_OPTION, CommonConstants.COST_PAPER_EXPORT_OPTION).ContinueWith(task =>
*/
        DisplayActionSheet("Exportar", Constants.CommonConstants.CANCEL_OPTION, null, Constants.CommonConstants.TECH_PAPER_EXPORT_OPTION, Constants.CommonConstants.COST_PAPER_EXPORT_OPTION).ContinueWith(task =>
        {

/* Cambio no fusionado mediante combinación del proyecto 'Servicing.Presentation.Terminal.MAUI.UI.Default (net8.0-android)'
Antes:
            if (task.IsCanceled || task.Result == null || task.Result == Contants.CommonConstants.CANCEL_OPTION) return;
Después:
            if (task.IsCanceled || task.Result == null || task.Result == CommonConstants.CANCEL_OPTION) return;
*/
            if (task.IsCanceled || task.Result == null || task.Result == Constants.CommonConstants.CANCEL_OPTION) return;

            Dispatcher.Dispatch(() => DisplayAlert("Aviso", "Funcionalidad en desarrollo.", "Aceptar"));
        });
    }

    private void DocumentDownloadButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel;

        if (concreteBindingContext.Document == null) return;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        BusyIndicatorGrid.IsVisible = true;

        var httpClient = new System.Net.Http.HttpClient
        {
            Timeout = System.TimeSpan.FromSeconds(30.0)
        };

        httpClient.GetByteArrayAsync($"{httpClientHelperProvider.HttpClientHelper.ClientBaseAddress}media/documents/{concreteBindingContext.Document.Id}{concreteBindingContext.Document.Extension}").ContinueWith(task =>
        {
            Dispatcher.Dispatch(async () =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"{concreteBindingContext.Document.Name}{concreteBindingContext.Document.Extension}", new System.IO.MemoryStream(task.Result));

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