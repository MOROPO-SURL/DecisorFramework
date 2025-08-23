using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick;

public partial class VacantPickPage : Caney.MVVM.Core.Pages.ContentPage
{
    private System.Action<Models.View.StaffVacantViewModel> pickCompleteAction;

    public VacantPickPage(System.Action<Models.View.StaffVacantViewModel> pickCompleteAction)
    {
        InitializeComponent();

        this.pickCompleteAction = pickCompleteAction;

        BindingContext = new Models.Page.Pick.VacantPickPageModel();

        IsEnabled = false;
    }

    private Models.Page.Pick.VacantPickPageModel ConcreteBindingContext { get => BindingContext as Models.Page.Pick.VacantPickPageModel; }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (IsEnabled) return;

        IsEnabled = true;

        ReloadToolbarItem_Clicked(this, System.EventArgs.Empty);
    }

    protected override void DisposeUnmanagementResources()
    {
        base.DisposeUnmanagementResources();

        pickCompleteAction = null;
    }

    private void ItemTapGestureRecognizer_Tapped(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var model = new Models.View.StaffVacantViewModel
        {
            Staff = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex],
            Vacant = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.VacantDisplayModel
        };

        pickCompleteAction.Invoke(model);

        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        ConcreteBindingContext.IsBusy = true;

        ConcreteBindingContext.AvailableStaffs.Clear();
        ConcreteBindingContext.Items.Clear();

        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    foreach (var model in task.Result)
                    {
                        ConcreteBindingContext.AvailableStaffs.Add(model);
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    protected void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        (Parent as Microsoft.Maui.Controls.NavigationPage).NavigationPopModalPageAsync();
    }

    private void StaffPicker_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
    {
        if (StaffPicker.SelectedIndex <= -1) return;

        LoadItems();
    }

    private void LoadItems()
    {
        if (StaffPicker.SelectedIndex <= -1) return;

        ConcreteBindingContext.IsBusy = true;

        var staff = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex];

        ConcreteBindingContext.Items.Clear();

        System.Threading.Tasks.Task.Run(async () =>
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

            var workforceAPIConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);
            var ocupationsAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

            var targetWorkforce = await workforceAPIConnectClient.GetAsync(staff.MainWorkforce.Id);

            var ocupations = new System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel>(await ocupationsAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.OcupationFilterModel { StaffId = staff.Id, WorkforceId = staff.MainWorkforce.Id }));

            foreach (var item in targetWorkforce.OrganizationalUnities)
            {
                var result = new Models.View.VacantPickOrganizationalUnityViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Enabled = item.Enabled,
                    Priority = item.Priority,
                    Reference = item.Reference
                };

                if (item.Vacants != null)
                {
                    var vacants = new System.Collections.Generic.List<Interop.API.Common.Models.Display.VacantDisplayModel>();

                    foreach (var vacant in item.Vacants)
                    {
                        var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == vacant.Id);

                        if (ocupation != null)
                        {
                            ocupations.Remove(ocupation);
                        }
                        else
                        {
                            vacants.Add(vacant);
                        }
                    }

                    result.Vacants = vacants.ToArray();
                }

                if (item.Children != null)
                {
                    result.Children = item.ToVacantPickOrganizationalUnityViewModelChildren(ocupations);
                }

                Dispatcher.Dispatch(() => ConcreteBindingContext.Items.Add(result));
            }
        }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }
}