using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class LeasingCollectsManagePage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<Models.View.LeasingCollectViewModel, Models.Page.Manage.LeasingCollectsManagePageModel>
{
    private const string CANCEL_OPTION = "Cancelar";
    private const string LEGAL_PROPERTY = "Inmueble por Cliente Jurídico";
    private const string LEGAL_VEHCILE = "Vehículo por Cliente Jurídico";
    private const string NATURAL_PROPERTY = "Inmueble por Cliente Natural";
    private const string NATURAL_VEHCILE = "Vehículo por Cliente Natural";

    public LeasingCollectsManagePage()
    {
        InitializeComponent();

        MonthPicker.ItemsSource = new string[] { "Enenro", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        MonthPicker.SelectedIndex = System.DateTime.Now.Month - 1;

        var years = new System.Collections.Generic.List<int>();

        var now = System.DateTime.Now;

        for (int i = now.Year; i >= 2000; i--)
        {
            years.Add(i);
        }
        
        YearPicker.ItemsSource = years.ToArray();
        YearPicker.SelectedItem = now.Year;
    }

    //protected override void ItemDetailRequestControl_Invoked(object sender, System.EventArgs eventArgs)
    //{
    //    if (((LeasingCollectsManagePage)BindingContext).IsBusy) return;

    //    var target = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.LeasingCollectViewModel;

    //    if (target.InteropModel is Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel)
    //    {
    //        this.NavigationPushModalPageAsync(new Detail.LegalClientVehicleLeasingCollectDetailPage(target.InteropModel as Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel, DetailActionDelegationRequest_Callback));
    //    }

    //    throw new System.InvalidOperationException();
    //}

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() => ItemsCollectionView;

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return -1;
    }

    protected override async System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<Models.View.LeasingCollectViewModel>> FetchItemsAsync()
    {
        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

        var legalClientPropertyLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingCollectsAPIConnectClient(httpClientHelperProvider);
        var legalClientVehicleLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.LegalClientVehicleLeasingCollectsAPIConnectClient(httpClientHelperProvider);
        var naturalClientPropertyLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.NaturalClientPropertyLeasingCollectsAPIConnectClient(httpClientHelperProvider);
        var naturalClientVehicleLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingCollectsAPIConnectClient(httpClientHelperProvider);

        var month = MonthPicker.SelectedIndex + 1;
        var year = (int)YearPicker.SelectedItem;

        var models = new System.Collections.Generic.List<Models.View.LeasingCollectViewModel>();

        var legalClientPropertyLeasingCollects = await legalClientPropertyLeasingCollectAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.LegalClientPropertyLeasingCollectFilterModel { Month = month, Year = year });

        foreach (var model in legalClientPropertyLeasingCollects)
        {
            models.Add(new Models.View.LeasingCollectViewModel { At = model.At, InteropModel = model });
        }

        var legalClientVehicleLeasingCollects = await legalClientVehicleLeasingCollectAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.LegalClientVehicleLeasingCollectFilterModel { Month = month, Year = year });

        foreach (var model in legalClientVehicleLeasingCollects)
        {
            models.Add(new Models.View.LeasingCollectViewModel { At = model.At, InteropModel = model });
        }

        var naturalClientPropertyLeasingCollects = await naturalClientPropertyLeasingCollectAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.NaturalClientPropertyLeasingCollectFilterModel { Month = month, Year = year });

        foreach (var model in naturalClientPropertyLeasingCollects)
        {
            models.Add(new Models.View.LeasingCollectViewModel { At = model.At, InteropModel = model });
        }

        var naturalClientVehicleLeasingCollects = await naturalClientVehicleLeasingCollectAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.NaturalClientVehicleLeasingCollectFilterModel { Month = month, Year = year });

        foreach (var model in naturalClientVehicleLeasingCollects)
        {
            models.Add(new Models.View.LeasingCollectViewModel { At = model.At, InteropModel = model });
        }

        return new Guama.Core.Presentation.Models.PaginationModel<Models.View.LeasingCollectViewModel>
        {
            HasNext = false,
            HasPrevious = false,
            MaxPageCount = 1,
            Page = 1,
            Limit = models.Count,
            List = models.OrderBy(model => model.At).ToList()
        };
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
    }

    private void AddItemToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        //if (CreatorPermissionCode != null)
        //{
        //    var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        //    if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == CreatorPermissionCode)))
        //    {
        //        DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

        //        return;
        //    }
        //}

        DisplayActionSheet("Agregar Cobro de Arrendamiento", CANCEL_OPTION, null, LEGAL_PROPERTY, LEGAL_VEHCILE, NATURAL_PROPERTY, NATURAL_VEHCILE).ContinueWith(task =>
        {
            var month = MonthPicker.SelectedIndex + 1;
            var year = (int)YearPicker.SelectedItem;

            var expectedAt = new System.DateTime(year, month, 1);

            Dispatcher.Dispatch(() =>
            {
                switch (task.Result)
                {
                    case LEGAL_PROPERTY:
                        this.NavigationPushPageAsync(new Configuration.LegalClientPropertyLeasingCollectConfigurationPage(LegalClientPropertyLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.LegalClientPropertyLeasingCollectConfigurationPageModel(expectedAt, null)));

                        break;

                    case LEGAL_VEHCILE:
                        this.NavigationPushPageAsync(new Configuration.LegalClientVehicleLeasingCollectConfigurationPage(LegalClientVehicleLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.LegalClientVehicleLeasingCollectConfigurationPageModel(expectedAt, null)));

                        break;

                    case NATURAL_PROPERTY:
                        this.NavigationPushPageAsync(new Configuration.NaturalClientPropertyLeasingCollectConfigurationPage(NaturalClientPropertyLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.NaturalClientPropertyLeasingCollectConfigurationPageModel(expectedAt, null)));

                        break;

                    case NATURAL_VEHCILE:
                        this.NavigationPushPageAsync(new Configuration.NaturalClientVehicleLeasingCollectConfigurationPage(NaturalClientVehicleLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.NaturalClientVehicleLeasingCollectConfigurationPageModel(expectedAt, null)));

                        break;

                    case CANCEL_OPTION:
                    default:
                        break;
                }
            });
        });
    }

    private void ItemsCollectionViewLayout_SizeChanged(object sender, System.EventArgs eventArgs)
    {
        OnItemsCollectionViewLayoutResize(sender, eventArgs);
    }

    private void DetailActionDelegationRequest_Callback(object target, int? discriminator)
    {
        if (discriminator == null)
        {
            //if (EditorPermissionCode != null)
            //{
            //    var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

            //    if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == EditorPermissionCode)))
            //    {
            //        DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            //        concreteBindingContext.IsBusy = false;

            //        return;
            //    }
            //}

            if (target is Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel legalClientPropertyLeasingCollectModel)
            {
                this.NavigationPushPageAsync(new Configuration.LegalClientPropertyLeasingCollectConfigurationPage(LegalClientPropertyLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.LegalClientPropertyLeasingCollectConfigurationPageModel(legalClientPropertyLeasingCollectModel.ExpectedAt, legalClientPropertyLeasingCollectModel)));

                return;
            }
            else if (target is Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel naturalClientPropertyLeasingCollectModel)
            {
                this.NavigationPushPageAsync(new Configuration.NaturalClientPropertyLeasingCollectConfigurationPage(NaturalClientPropertyLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.NaturalClientPropertyLeasingCollectConfigurationPageModel(naturalClientPropertyLeasingCollectModel.ExpectedAt, naturalClientPropertyLeasingCollectModel)));

                return;
            }
            else if (target is Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel legalClientVehicleLeasingCollectModel)
            {
                this.NavigationPushPageAsync(new Configuration.LegalClientVehicleLeasingCollectConfigurationPage(LegalClientVehicleLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.LegalClientVehicleLeasingCollectConfigurationPageModel(legalClientVehicleLeasingCollectModel.ExpectedAt, legalClientVehicleLeasingCollectModel)));

                return;
            }
            else if (target is Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel naturalClientVehicleLeasingCollectModel)
            {
                this.NavigationPushPageAsync(new Configuration.NaturalClientVehicleLeasingCollectConfigurationPage(NaturalClientVehicleLeasingCollectConfigurationSuccess_Callback, new Models.Page.Configuration.NaturalClientVehicleLeasingCollectConfigurationPageModel(naturalClientVehicleLeasingCollectModel.ExpectedAt, naturalClientVehicleLeasingCollectModel)));

                return;
            }
        }
        else if (discriminator == 0)
        {
            if (target is Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel legalClientPropertyLeasingCollectModel)
            {
                var legalClientPropertyLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.LegalClientPropertyLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                legalClientPropertyLeasingCollectAPIConnectClient.ArchiveAsync(legalClientPropertyLeasingCollectModel.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                return;
            }
            else if (target is Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel naturalClientPropertyLeasingCollectModel)
            {
                var naturalClientPropertyLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.NaturalClientPropertyLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                naturalClientPropertyLeasingCollectAPIConnectClient.ArchiveAsync(naturalClientPropertyLeasingCollectModel.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                return;
            }
            else if (target is Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel legalClientVehicleLeasingCollectModel)
            {
                var legalClientVehicleLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.LegalClientVehicleLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                legalClientVehicleLeasingCollectAPIConnectClient.ArchiveAsync(legalClientVehicleLeasingCollectModel.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                return;
            }
            else if (target is Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel naturalClientVehicleLeasingCollectModel)
            {
                var naturalClientVehicleLeasingCollectAPIConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                naturalClientVehicleLeasingCollectAPIConnectClient.ArchiveAsync(naturalClientVehicleLeasingCollectModel.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });

                return;
            }
        }

        throw new System.InvalidOperationException();
    }

    protected void LegalClientVehicleLeasingCollectConfigurationSuccess_Callback(Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel model)
    {
        LoadItems(true);
    }

    protected void LegalClientPropertyLeasingCollectConfigurationSuccess_Callback(Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel model)
    {
        LoadItems(true);
    }

    protected void NaturalClientVehicleLeasingCollectConfigurationSuccess_Callback(Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel model)
    {
        LoadItems(true);
    }

    protected void NaturalClientPropertyLeasingCollectConfigurationSuccess_Callback(Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel model)
    {
        LoadItems(true);
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (((Models.Page.Manage.LeasingCollectsManagePageModel)BindingContext).IsBusy) return;

        var target = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.LeasingCollectViewModel;

        if (target.InteropModel is Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel)
        {
            this.NavigationPushModalPageAsync(new Detail.LegalClientVehicleLeasingCollectDetailPage(target.InteropModel as Interop.API.Common.Models.Display.LegalClientVehicleLeasingCollectDisplayModel, DetailActionDelegationRequest_Callback));

            return;
        }
        else if (target.InteropModel is Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel)
        {
            this.NavigationPushModalPageAsync(new Detail.NaturalClientVehicleLeasingCollectDetailPage(target.InteropModel as Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel, DetailActionDelegationRequest_Callback));

            return;
        }
        else if (target.InteropModel is Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel)
        {
            this.NavigationPushModalPageAsync(new Detail.NaturalClientPropertyLeasingCollectDetailPage(target.InteropModel as Interop.API.Common.Models.Display.NaturalClientPropertyLeasingCollectDisplayModel, DetailActionDelegationRequest_Callback));

            return;
        }
        else if (target.InteropModel is Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel)
        {
            this.NavigationPushModalPageAsync(new Detail.LegalClientPropertyLeasingCollectDetailPage(target.InteropModel as Interop.API.Common.Models.Display.LegalClientPropertyLeasingCollectDisplayModel, DetailActionDelegationRequest_Callback));

            return;
        }

        throw new System.InvalidOperationException();
    }
}