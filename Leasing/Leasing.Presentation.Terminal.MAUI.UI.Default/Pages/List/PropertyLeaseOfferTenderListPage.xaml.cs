using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.List;

public partial class PropertyLeaseOfferTenderListPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ListBaseContentPage<PropertyLeaseOfferDisplayModel, Models.Page.List.PropertyLeaseOfferTenderListPageModel>
{
    public PropertyLeaseOfferTenderListPage()
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

    protected override System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<PropertyLeaseOfferDisplayModel>> FetchItemsAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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

    private void OganizationPostulationViewLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Detail.PropertyLeaseOrganizationPostulationDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeaseOrganizationPostulationDisplayModel));
    }

    private void PersonPostulationViewLayoutTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        this.NavigationPushModalPageAsync(new Detail.PropertyLeasePersonPostulationDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeasePersonPostulationDisplayModel));
    }

    private void OrganizationPostulationApproveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var upstreamTarget = ((Microsoft.Maui.Controls.Button)sender).Parent.Parent.Parent.BindingContext as PropertyLeaseOfferDisplayModel;

        (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var paymentTermsAPIConnectClient = new Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
            var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(httpClientHelperProvider);

            var model = new Models.Page.Configuration.LegalClientPropertyLeasingConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as PropertyLeaseOrganizationPostulationDisplayModel, null)
            {
                AvailablePaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync(),
                AvailableConstCenters = await costCentersAPIConnectClient.FilterAsync(new Financial.Interop.API.Common.Models.Filter.CostCenterFilterModel { StructureId = upstreamTarget.Propousal.Property.Structure.Id })
            };

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPushPageAsync(new Configuration.LegalClientPropertyLeasingConfigurationPage(OrganizationPostulationLeasingConfigurationSuccess_Callback, model));

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsCanceled && task.Exception == null) return;

            Dispatcher.Dispatch(() =>
            {
                Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void PersonPostulationApproveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var upstreamTarget = ((Microsoft.Maui.Controls.Button)sender).Parent.Parent.Parent.BindingContext as PropertyLeaseOfferDisplayModel;

        (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

            var paymentTermsAPIConnectClient = new Commercial.Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
            var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(httpClientHelperProvider);

            var model = new Models.Page.Configuration.NaturalClientPropertyLeasingConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as PropertyLeasePersonPostulationDisplayModel, null)
            {
                AvailablePaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync(),
                AvailableConstCenters = await costCentersAPIConnectClient.FilterAsync(new Financial.Interop.API.Common.Models.Filter.CostCenterFilterModel { StructureId = upstreamTarget.Propousal.Property.Structure.Id })
            };

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPushPageAsync(new Configuration.NaturalClientPropertyLeasingConfigurationPage(PersonPostulationLeasingConfigurationSuccess_Callback, model));

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
            });
        }).ContinueWith(task =>
        {
            if (!task.IsCanceled && task.Exception == null) return;

            Dispatcher.Dispatch(() =>
            {
                Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void OrganizationPostulationAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new Configuration.PropertyLeaseOrganizationPostulationConfigurationPage(OrganizationPostulationConfigurationSuccess_Callback, new Models.Page.Configuration.PropertyLeaseOrganizationPostulationConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as PropertyLeaseOfferDisplayModel, null)));
    }

    private void OrganizationPostulationEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeaseOrganizationPostulationDisplayModel;

        this.NavigationPushPageAsync(new Configuration.PropertyLeaseOrganizationPostulationConfigurationPage(OrganizationPostulationConfigurationSuccess_Callback, new Models.Page.Configuration.PropertyLeaseOrganizationPostulationConfigurationPageModel((sender as Microsoft.Maui.Controls.View).Parent.Parent.Parent.BindingContext as PropertyLeaseOfferDisplayModel, target)));
    }

    private void PersonPostulationAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

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
                    var model = new Models.Page.Configuration.PropertyLeasePersonPostulationConfigurationPageModel((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as PropertyLeaseOfferDisplayModel, null)
                    {
                        AvailableBusinessKinds = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.PropertyLeasePersonPostulationConfigurationPage(PersonPostulationConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
            });
        });
    }

    private void PersonPostulationEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var businessKindsAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

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
                    var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeasePersonPostulationDisplayModel;

                    var model = new Models.Page.Configuration.PropertyLeasePersonPostulationConfigurationPageModel((sender as Microsoft.Maui.Controls.View).Parent.Parent.Parent.BindingContext as PropertyLeaseOfferDisplayModel, target)
                    {
                        AvailableBusinessKinds = task.Result
                    };

                    this.NavigationPushPageAsync(new Configuration.PropertyLeasePersonPostulationConfigurationPage(PersonPostulationConfigurationSuccess_Callback, model));
                }

                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = false;
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
                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeaseOrganizationPostulationDisplayModel;

                var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeaseOrganizationPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

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
                (BindingContext as Models.Page.List.PropertyLeaseOfferTenderListPageModel).IsBusy = true;

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PropertyLeasePersonPostulationDisplayModel;

                var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePersonPostulationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                apiConnectClient.DeleteAsync(target.Id).ContinueWith(task =>
                {
                    Dispatcher.Dispatch(() => LoadItems(true));
                });
            });
        });
    }

    private void OrganizationPostulationConfigurationSuccess_Callback(PropertyLeaseOrganizationPostulationDisplayModel model)
    {
        LoadItems(true);
    }

    private void PersonPostulationConfigurationSuccess_Callback(PropertyLeasePersonPostulationDisplayModel model)
    {
        LoadItems(true);
    }
    protected void OrganizationPostulationLeasingConfigurationSuccess_Callback(LegalClientPropertyLeasingDisplayModel model)
    {
        LoadItems(true);
    }

    protected void PersonPostulationLeasingConfigurationSuccess_Callback(NaturalClientPropertyLeasingDisplayModel model)
    {
        LoadItems(true);
    }
}