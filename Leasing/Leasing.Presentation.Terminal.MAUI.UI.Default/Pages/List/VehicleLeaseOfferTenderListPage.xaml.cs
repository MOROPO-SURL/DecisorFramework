using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class VehicleLeaseOfferTenderListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<VehicleLeaseOfferDisplayModel, Models.Page.List.VehicleLeaseOfferTenderListPageModel>
{
    public VehicleLeaseOfferTenderListPage()
    {
        InitializeComponent();
    }

    protected override Microsoft.Maui.Controls.CollectionView GetItemsCollectionView()
    {
        return ItemsCollectionView;
    }

    protected override double MeasureCollectionViewCellHeight(double width)
    {
        return -1;
    }

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<VehicleLeaseOfferDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        return apiConnectClient.GetPaginateAsync();
    }

    private void ReloadToolbarItems_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnReload(sender, eventArgs);
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
        base.ItemDetailRequestControl_Invoked(sender, System.EventArgs.Empty);
    }

    private void OrganizationPostulationApproveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var apiConnectClient = new Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

        apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var model = new Models.Page.Configuration.LegalClientVehicleLeasingConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as VehicleLeaseOrganizationPostulationDisplayModel, null)
                    {
                        AvailablePaymentTerms = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.LegalClientVehicleLeasingConfigurationPage(OrganizationPostulationLeasingConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void PersonPostulationApproveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var apiConnectClient = new Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

        apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var model = new Models.Page.Configuration.NaturalClientVehicleLeasingConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as VehicleLeasePersonPostulationDisplayModel, null)
                    {
                        AvailablePaymentTerms = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.NaturalClientVehicleLeasingConfigurationPage(PersonPostulationLeasingConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void OganizationPostulationViewLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Detail.VehicleLeaseOrganizationPostulationDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeaseOrganizationPostulationDisplayModel));
    }

    private void PersonPostulationViewLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Detail.VehicleLeasePersonPostulationDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeasePersonPostulationDisplayModel));
    }

    private void OrganizationPostulationAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new Configuration.VehicleLeaseOrganizationPostulationConfigurationPage(OrganizationPostulationConfigurationSuccess_Callback, new Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel(((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as VehicleLeaseOfferDisplayModel).Id, null)));
    }

    private void OrganizationPostulationEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeaseOrganizationPostulationDisplayModel;

        this.NavigationPushPageAsync(new Configuration.VehicleLeaseOrganizationPostulationConfigurationPage(OrganizationPostulationConfigurationSuccess_Callback, new Models.Page.Configuration.VehicleLeaseOrganizationPostulationConfigurationPageModel(((sender as Microsoft.Maui.Controls.View).Parent.Parent.Parent.BindingContext as VehicleLeaseOfferDisplayModel).Id, target)));
    }

    private void PersonPostulationAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

        businessKindsAPIConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var model = new Models.Page.Configuration.VehicleLeasePersonPostulationConfigurationPageModel(((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as VehicleLeaseOfferDisplayModel).Id, null)
                    {
                        AvailableBusinessKinds = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.VehicleLeasePersonPostulationConfigurationPage(PersonPostulationConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void PersonPostulationEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

        businessKindsAPIConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.IsCanceled || task.Exception != null)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeasePersonPostulationDisplayModel;

                    var model = new Models.Page.Configuration.VehicleLeasePersonPostulationConfigurationPageModel(((sender as Microsoft.Maui.Controls.View).Parent.Parent.Parent.BindingContext as VehicleLeaseOfferDisplayModel).Id, target)
                    {
                        AvailableBusinessKinds = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.VehicleLeasePersonPostulationConfigurationPage(PersonPostulationConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void OrganizationPostulationRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta postulación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeaseOrganizationPostulationDisplayModel;

                var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.DeleteAsync(target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });
            });
        });
    }

    private void PersonPostulationRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta postulación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                (BindingContext as Models.Page.List.VehicleLeaseOfferTenderListPageModel).IsBusy = true;

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as VehicleLeasePersonPostulationDisplayModel;

                var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.DeleteAsync(target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });
            });
        });
    }

    private void OrganizationPostulationConfigurationSuccess_Callback(VehicleLeaseOrganizationPostulationDisplayModel model)
    {
        LoadItems(true);
    }

    private void PersonPostulationConfigurationSuccess_Callback(VehicleLeasePersonPostulationDisplayModel model)
    {
        LoadItems(true);
    }

    protected void OrganizationPostulationLeasingConfigurationSuccess_Callback(LegalClientVehicleLeasingDisplayModel model)
    {
        LoadItems(true);
    }

    protected void PersonPostulationLeasingConfigurationSuccess_Callback(NaturalClientVehicleLeasingDisplayModel model)
    {
        LoadItems(true);
    }
}