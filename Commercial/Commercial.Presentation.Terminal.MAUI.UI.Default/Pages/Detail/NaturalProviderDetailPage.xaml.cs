using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalProviderDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, int?> delegationAction;

    public NaturalProviderDetailPage(Interop.API.Common.Models.Display.NaturalProviderDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;

        OptionsStackLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.NaturalProviderDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            // null for Edit
            Dispatcher.Dispatch(() => delegationAction.Invoke(model, null));
        });
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.NaturalProviderRemoverPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para retirar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalProviderDisplayModel;

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

    private void ContactDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel>>();

        var page = factory.Build((BindingContext as Interop.API.Common.Models.Display.NaturalProviderDisplayModel).Contact);

        this.NavigationPushModalPageAsync(page);
    }

    private void DocumentDownloadButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Core.Interop.API.Common.Models.Display.DocumentDisplayModel;

        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

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
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var fileSaverResult = await CommunityToolkit.Maui.Storage.FileSaver.Default.SaveAsync($"{model.Name}{model.Extension}", new System.IO.MemoryStream(task.Result));

                    if (fileSaverResult.IsSuccessful)
                    {
                        this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Archivo descargado con éxito.");
                    }
                    else if (fileSaverResult.FilePath != null)
                    {
                        this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Error, "No fue posible salvar el archivo.");
                    }
                }

                BusyIndicatorGrid.IsVisible = false;
            });
        });
    }
}