using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;
using System.Threading.Tasks;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class OcupationsRawManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    private Models.View.OcupationsRawManageVacantViewModel pickContactVacantBindingContext;

	public OcupationsRawManagePage()
	{
		InitializeComponent();

        BindingContext = new Models.Page.Manage.OcupationsManagePageModel();

        IsEnabled = false;
    }

    private Models.Page.Manage.OcupationsManagePageModel ConcreteBindingContext { get => BindingContext as Models.Page.Manage.OcupationsManagePageModel; }

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

        pickContactVacantBindingContext = null;
    }

    private void ReloadToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        if (ConcreteBindingContext.IsBusy) return;

        ConcreteBindingContext.IsBusy = true;

        ConcreteBindingContext.AvailableStaffs.Clear();
        ConcreteBindingContext.AvailableStaffWorkforces.Clear();
        ConcreteBindingContext.OrganizationalUnities.Clear();
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

    private void StaffPicker_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
    {
        if (StaffPicker.SelectedIndex <= -1) return;

        var target = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex];

        ConcreteBindingContext.AvailableStaffWorkforces.Clear();

        ConcreteBindingContext.AvailableStaffWorkforces.Add(new Models.View.StaffWorkforceViewModel { Title = $"Principal ({target.MainWorkforce.Name})", Workforce = target.MainWorkforce });

        foreach (var item in target.AlternativeWorkforces)
        {
            ConcreteBindingContext.AvailableStaffWorkforces.Add(new Models.View.StaffWorkforceViewModel { Title = $"{item.Title} ({item.Workforce.Name})", Workforce = item.Workforce });
        }
    }

    private void StaffWorkforcePicker_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
    {
        LoadItems();
    }

    private void LoadItems()
    {
        if (StaffPicker.SelectedIndex <= -1) return;

        if (StaffWorkforcePicker.SelectedIndex <= -1) return;

        ConcreteBindingContext.IsBusy = true;

        var staffId = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex].Id;
        var targetWorkforceId = ConcreteBindingContext.AvailableStaffWorkforces[StaffWorkforcePicker.SelectedIndex].Workforce.Id;

        ConcreteBindingContext.Items.Clear();

        System.Threading.Tasks.Task.Run(async () => 
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

            var workforceAPIConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);
            var ocupationsAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

            var targetWorkforce = await workforceAPIConnectClient.GetAsync(targetWorkforceId);

            var ocupations = new System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel>(await ocupationsAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.OcupationFilterModel { StaffId = staffId, WorkforceId = targetWorkforceId }));

            Dispatcher.Dispatch(() =>
            {
                foreach (var item in targetWorkforce.OrganizationalUnities)
                {
                    var result = new Models.View.OcupationsRawManageOrganizationalUnityViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Enabled = item.Enabled,
                        Priority = item.Priority,
                        Reference = item.Reference
                    };

                    if (item.Vacants != null)
                    {
                        result.Vacants = item.Vacants.Select(_model =>
                        {
                            var ocupation = ocupations.FirstOrDefault(_item => _item.VacantId == _model.Id);

                            var result = new Models.View.OcupationsRawManageVacantViewModel
                            {
                                Id = _model.Id,
                                NamingResolutionRequired = _model.NamingResolutionRequired,
                                WorkPosition = _model.WorkPosition,
                                SalaryStandard = _model.SalaryStandard,
                                Ocupation = ocupation
                            };

                            if (ocupation != null) ocupations.Remove(ocupation);

                            return result;
                        }).ToArray();
                    }

                    if (item.Children != null)
                    {
                        result.Children = item.ToOrganizationalUnityViewModelChildren(ocupations);
                    }

                    ConcreteBindingContext.OrganizationalUnities.Add(result);
                }
            });
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

    private void PickContactButton_Clicked(object sender, System.EventArgs e)
    {
        pickContactVacantBindingContext = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsRawManageVacantViewModel;

        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Delay(100).ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() => this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback))).ContinueWith(_ => Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = false)));
        });
    }

    private void RemoveOcupationButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea remover la persona asignada de esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = true;

                var ocupationsAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsRawManageVacantViewModel;

                ocupationsAPIConnectClient.DeleteAsync(model.Ocupation.Id).ContinueWith(_task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, this);
                        }
                        else
                        {
                            model.Ocupation = null;
                        }

                        ConcreteBindingContext.IsBusy = false;
                    });
                });
            });
        });
    }

    private void EmployeeDetailButton_Clicked(object sender, System.EventArgs e)
    {
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsRawManageVacantViewModel;

        var employeesAPIConnectClient = new Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;
        
        employeesAPIConnectClient.GetAsync(model.Ocupation.Employee.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.EmployeeDisplayModel, Detail.EmployeeDetailPage>>();

                try
                {
                    var page = factory.Build(task.Result, null, null);

                    this.NavigationPushModalPageAsync(page);
                }
                catch (System.Exception exception)
                {
                    DisplayAlert("Aviso", string.Format("Unspected runtime error!! {0}", exception.Message), "Aceptar");
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });        
    }

    private void ContactPickComplete_Callback(PersonContactDisplayModel model)
    {
        if (pickContactVacantBindingContext.Ocupation != null && pickContactVacantBindingContext.Ocupation.Employee.Contact.Id == model.Id)
        {
            pickContactVacantBindingContext = null;

            return;
        }

        DisplayAlert("Confirmación", "Está seguro que desea asignar la persona seleccionada a esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = true;

                System.Threading.Tasks.Task.Run(async () =>
                {
                    var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

                    var employeesAPIConnectClient = new Interop.API.Connect.Clients.EmployeesAPIConnectClient(httpClientHelperProvider);

                    Interop.API.Common.Models.Display.EmployeeDisplayModel employee;

                    try
                    {
                        employee = await employeesAPIConnectClient.FindByContactAsync(model.Id);
                    }
                    catch (Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException exception)
                    {
                        if (exception.HttpStatusCode != System.Net.HttpStatusCode.NoContent) throw;

                        var employeeId = System.Guid.NewGuid();

                        await employeesAPIConnectClient.CreateAsync(new Interop.API.Common.Models.Input.EmployeeInputModel
                        {
                            Id = employeeId,
                            ContactId = model.Id,
                            Priority = 1
                        });

                        employee = await employeesAPIConnectClient.GetAsync(employeeId);
                    }
                    catch { throw; }

                    var ocupationsAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

                    if (pickContactVacantBindingContext.Ocupation != null)
                    {
                        await ocupationsAPIConnectClient.EditAsync(new Interop.API.Common.Models.Input.OcupationInputModel
                        {
                            Id = pickContactVacantBindingContext.Ocupation.Id,
                            EmployeeId = employee.Id
                        });

                        return await ocupationsAPIConnectClient.GetAsync(pickContactVacantBindingContext.Ocupation.Id);
                    }

                    var newOcupationId = System.Guid.NewGuid();

                    await ocupationsAPIConnectClient.CreateAsync(new Interop.API.Common.Models.Input.OcupationInputModel
                    {
                        Id = newOcupationId,
                        StaffId = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex].Id,
                        WorkforceId = ConcreteBindingContext.AvailableStaffWorkforces[StaffWorkforcePicker.SelectedIndex].Workforce.Id,
                        VacantId = pickContactVacantBindingContext.Id,
                        EmployeeId = employee.Id
                    });

                    return await ocupationsAPIConnectClient.GetAsync(newOcupationId);
                }).ContinueWith(_task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, this);
                        }
                        else
                        {
                            pickContactVacantBindingContext.Ocupation = _task.Result;
                        }

                        pickContactVacantBindingContext = null;

                        ConcreteBindingContext.IsBusy = false;
                    });
                });
            });
        });
    }
}