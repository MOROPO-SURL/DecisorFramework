using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class ChangeNotificationsListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Models.View.ChangeNotificationViewModel, Models.Page.List.ChangeNotificationsListPageModel>
{
    private const string OPTIONS_MARK_AS_READED = "Marcar como leída";
    private const string OPTIONS_MARK_AS_NO_READED = "Marcar como no leída";
    private const string OPTIONS_DETAILS = "Detalles";
    private const string OPTIONS_DELETE = "Eliminar";
    private const string OPTIONS_CANCEL = "Cancelar";

    public ChangeNotificationsListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override async System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Models.View.ChangeNotificationViewModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var result = await apiConnectClient.GetPaginateAsync(CurrentItemsPageNumber, CurrentItemsPageLimit);

        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<MAUI.Factories.Facade.IChangeNotificationViewModelFactoryFacade>();

        return new Guama.Core.Presentation.Models.PaginationModel<Models.View.ChangeNotificationViewModel>
        {
            Page = result.Page,
            HasNext = result.HasNext,
            HasPrevious = result.HasPrevious,
            Limit = result.Limit,
            MaxPageCount = result.MaxPageCount,
            List = result.List.Select(item => factory.Build(item)).ToList()
        };
    }

    private void MarkAllAsReadedToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Aviso", "Está seguro que desea marcar todas las notificaciones como leidas?", "Aceptar", "Cancelar").ContinueWith(async task =>
        {
            if (!task.Result) return;

            var apiConnectClient = new Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            try
            {
                await apiConnectClient.MarkAllAsReadedAsync();

                Dispatcher.Dispatch(() =>
                {
                    this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");

                    LoadItems(true);
                });
            }
            catch
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                    ConcreteBindingContext.IsBusy = false;
                });
            }
        });
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void BackToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPopModalPageAsync();
    }

    private void LoadMoreBurron_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnLoadMore(sender, eventArgs);
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        OnItemsCollectionViewLayoutResize(sender, eventArgs);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (ConcreteBindingContext.IsBusy) return;

        var target = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.ChangeNotificationViewModel;

        if (target.Model.ReadedAt != null)
        {
            PresentDetailPage(target);

            return;
        }

        var apiConnectClient = new Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;

        apiConnectClient.MarkAsReadedAsync(target.Model.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                    ConcreteBindingContext.IsBusy = false;
                }
                else
                {
                    LoadItems(true);

                    PresentDetailPage(target);
                }
            });
        });
    }

    private void NotificationOptionsButton_Clicked(object sender, System.EventArgs e)
    {
        var target = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.ChangeNotificationViewModel;

        DisplayActionSheet("Opciones", OPTIONS_CANCEL, null, target.Model.ReadedAt == null ? OPTIONS_MARK_AS_READED : OPTIONS_MARK_AS_NO_READED, OPTIONS_DETAILS, OPTIONS_DELETE).ContinueWith(async task =>
        {
            var apiConnectClient = new Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            switch (task.Result)
            {
                case OPTIONS_MARK_AS_READED:
                    try
                    {
                        Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = true);

                        await apiConnectClient.MarkAsReadedAsync(target.Model.Id);

                        Dispatcher.Dispatch(() =>
                        {
                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");

                            LoadItems(true);
                        });
                    }
                    catch
                    {
                        Dispatcher.Dispatch(() =>
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                            ConcreteBindingContext.IsBusy = false;
                        });
                    }

                    break;

                case OPTIONS_MARK_AS_NO_READED:
                    try
                    {
                        Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = true);

                        await apiConnectClient.MarkAsNotReadedAsync(target.Model.Id);

                        Dispatcher.Dispatch(() =>
                        {
                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");

                            LoadItems(true);
                        });
                    }
                    catch
                    {
                        Dispatcher.Dispatch(() =>
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                            ConcreteBindingContext.IsBusy = false;
                        });
                    }

                    break;

                case OPTIONS_DELETE:
                    Dispatcher.Dispatch(() =>
                    {
                        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(async task =>
                        {
                            if (!task.Result) return;

                            try
                            {
                                Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = true);

                                await apiConnectClient.DeleteAsync(target.Model.Id);

                                Dispatcher.Dispatch(() =>
                                {
                                    this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Elemento eliminado con éxito.");

                                    LoadItems(true);
                                });
                            }
                            catch
                            {
                                Dispatcher.Dispatch(() =>
                                {
                                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                                    ConcreteBindingContext.IsBusy = false;
                                });
                            }
                        });
                    });                    

                    break;

                case OPTIONS_CANCEL:
                default:
                    break;
            }
        });
    }

    private void DetailActionDelegationRequest_Callback(Models.View.ChangeNotificationViewModel target, int? discriminator)
    {
        ConcreteBindingContext.IsBusy = true;

        var apiConnectClient = new Interop.API.Connect.Clients.ChangeNotificationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        apiConnectClient.DeleteAsync(target.Model.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Elemento eliminado con éxito.");

                LoadItems(true);
            });
        });
    }

    private void PresentDetailPage(Models.View.ChangeNotificationViewModel model)
    {
        var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.View.ChangeNotificationViewModel>>();

        try
        {
            var page = factory.Build(model, DetailActionDelegationRequest_Callback);

            this.NavigationPushModalPageAsync(page);
        }
        catch (System.Exception exception)
        {
            DisplayAlert("Aviso", string.Format("Unspected runtime error!! {0}", exception.Message), "Aceptar");

            return;
        }
    }
}