using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class NaturalClientByContactBankAccountPickPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel, Models.Page.Pick.CommonClientByContactBankAccountPickPageModel>
{
    public static double ITEM_VIEW_REQUEST_HEIGHT = 160;

    private System.Action<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> pickCompleteAction;
    private readonly Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel person;

    private bool pickedFlag = false;

    public NaturalClientByContactBankAccountPickPage(System.Action<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel> pickCompleteAction, Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel person)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;
        this.person = person;

        IsEnabled = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled && pickedFlag)
        {
            (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();

            return;
        }

        IsEnabled = true;
    }

    protected override double ItemViewRequestWidth { get => 360; }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    protected override async System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        try
        {
            var client = await apiConnectClient.GetByContactAsync(person.Id);

            return new Guama.Core.Presentation.Models.PaginationModel<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel>
            {
                HasNext = false,
                HasPrevious = false,
                MaxPageCount = 1,
                Page = 1,
                Limit = client?.BankAccounts.Length ?? 0,
                List = client?.BankAccounts.ToList() ?? []
            };
        }
        catch (Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException exception)
        {
            if (exception.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return new Guama.Core.Presentation.Models.PaginationModel<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel>
                {
                    HasNext = false,
                    HasPrevious = false,
                    MaxPageCount = 1,
                    Page = 1,
                    Limit = 0,
                    List = []
                };
            }

            throw;
        }
        catch
        {
            throw;
        }
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void AddToolbarItem_Clicked(object sender, System.EventArgs e)
    {
        // TODO Uncomment an fix block code!!
        //var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        //if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.LegalClientCreatorPermission)))
        //{
        //    DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

        //    return;
        //}

        var concreteBindingContext = BindingContext as Models.Page.Pick.CommonClientByContactBankAccountPickPageModel;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel, Financial.Presentation.Terminal.MAUI.Models.Page.Configuration.BankAccountConfigurationPageModel>>();

                var page = await factory.BuildAsync(ConfigurationSuccess_Callback, null);

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(page);
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);

                    concreteBindingContext.IsBusy = false;
                });
            }
        });
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
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
        pickCompleteAction.Invoke(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ConfigurationSuccess_Callback(Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel model)
    {
        Dispatcher.Dispatch(() => pickCompleteAction.Invoke(model));

        pickedFlag = true;
    }
}