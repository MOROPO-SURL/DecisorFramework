using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages.Manage;

public partial class OcupationsSimplifiedManagePage : Framework.Caney.MVVM.Core.Pages.ContentPage
{
    private Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.OcupationsRawManageVacantViewModel pickContactVacantBindingContext;

	public OcupationsSimplifiedManagePage()
	{
		InitializeComponent();

        BindingContext = new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Manage.OcupationsManagePageModel();

        IsEnabled = false;
    }

    private Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Manage.OcupationsManagePageModel ConcreteBindingContext { get => BindingContext as Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Manage.OcupationsManagePageModel; }

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

        var apiConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        apiConnectClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
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

        ConcreteBindingContext.AvailableStaffWorkforces.Add(new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.StaffWorkforceViewModel { Title = $"Principal ({target.MainWorkforce.Name})", Workforce = target.MainWorkforce });

        foreach (var item in target.AlternativeWorkforces)
        {
            ConcreteBindingContext.AvailableStaffWorkforces.Add(new Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.StaffWorkforceViewModel { Title = $"{item.Title} ({item.Workforce.Name})", Workforce = item.Workforce });
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

            var workforceAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);
            var ocupationsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

            var targetWorkforce = await workforceAPIConnectClient.GetAsync(targetWorkforceId);

            var ocupations = new System.Collections.Generic.List<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel>(await ocupationsAPIConnectClient.FilterAsync(new Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter.OcupationFilterModel { StaffId = staffId, WorkforceId = targetWorkforceId }));

            var _models = targetWorkforce.OrganizationalUnities.ToOcupationsRawManageOrganizationalUnityViewModelChildren(ocupations);

            Dispatcher.Dispatch(() =>
            {
                foreach (var _model in _models)
                {
                    ConcreteBindingContext.OrganizationalUnities.Add(_model);
                }
            });
        }).ContinueWith(task => 
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void OcupationCreationButton_Clicked(object sender, System.EventArgs e)
    {
        pickContactVacantBindingContext = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.OcupationsRawManageVacantViewModel;
    }

    //private void PickContactButton_Clicked(object sender, System.EventArgs e)
    //{
    //    pickContactVacantBindingContext = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.OcupationsRawManageVacantViewModel;

    //    ConcreteBindingContext.IsBusy = true;

    //    System.Threading.Tasks.Task.Delay(100).ContinueWith(_ =>
    //    {
    //        Dispatcher.Dispatch(() => this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback))).ContinueWith(_ => Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = false)));
    //    });
    //}

    private void RemoveOcupationButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea remover la persona asignada de esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = true;

                var ocupationsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.OcupationsRawManageVacantViewModel;

                ocupationsAPIConnectClient.DeleteAsync(model.Ocupation.Id).ContinueWith(_task =>
                {
                    Dispatcher.Dispatch(() =>
                    {
                        if (_task.Exception != null || _task.IsCanceled)
                        {
                            Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, this);
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
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View.OcupationsRawManageVacantViewModel;

        var employeesAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;
        
        employeesAPIConnectClient.GetAsync(model.Ocupation.Employee.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>>();

                try
                {
                    var page = factory.Build(task.Result);

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

    private void OcupationConfigurationComplete_Callback(Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel model)
    {
        pickContactVacantBindingContext.Ocupation = model;

        pickContactVacantBindingContext = null;
    }

    //private void ContactPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    //{
    //    if (pickContactVacantBindingContext.Ocupation != null && pickContactVacantBindingContext.Ocupation.Employee.Contact.Id == model.Id)
    //    {
    //        pickContactVacantBindingContext = null;

    //        return;
    //    }

    //    DisplayAlert("Confirmación", "Está seguro que desea asignar la persona seleccionada a esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(task =>
    //    {
    //        if (!task.Result) return;

    //        Dispatcher.Dispatch(() =>
    //        {
    //            ConcreteBindingContext.IsBusy = true;

    //            System.Threading.Tasks.Task.Run(async () =>
    //            {
    //                var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

    //                var employeesAPIConnectClient = new Framework.Decisor.Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(httpClientHelperProvider);

    //                Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel employee;

    //                try
    //                {
    //                    employee = await employeesAPIConnectClient.FindByContactAsync(model.Id);
    //                }
    //                catch (Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException exception)
    //                {
    //                    if (exception.HttpStatusCode != System.Net.HttpStatusCode.NoContent) throw;

    //                    var employeeId = System.Guid.NewGuid();

    //                    await employeesAPIConnectClient.CreateAsync(new Framework.Decisor.Domain.Interop.API.Common.Models.Input.EmployeeInputModel
    //                    {
    //                        Id = employeeId,
    //                        ContactId = model.Id,
    //                        Priority = 1
    //                    });

    //                    employee = await employeesAPIConnectClient.GetAsync(employeeId);
    //                }
    //                catch { throw; }

    //                var ocupationsAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

    //                if (pickContactVacantBindingContext.Ocupation != null)
    //                {
    //                    await ocupationsAPIConnectClient.EditAsync(new Framework.Decisor.HumanResources.Interop.API.Common.Models.Input.OcupationInputModel
    //                    {
    //                        Id = pickContactVacantBindingContext.Ocupation.Id,
    //                        EmployeeId = employee.Id
    //                    });

    //                    return await ocupationsAPIConnectClient.GetAsync(pickContactVacantBindingContext.Ocupation.Id);
    //                }

    //                var newOcupationId = System.Guid.NewGuid();

    //                await ocupationsAPIConnectClient.CreateAsync(new Framework.Decisor.HumanResources.Interop.API.Common.Models.Input.OcupationInputModel
    //                {
    //                    Id = newOcupationId,
    //                    StaffId = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex].Id,
    //                    WorkforceId = ConcreteBindingContext.AvailableStaffWorkforces[StaffWorkforcePicker.SelectedIndex].Workforce.Id,
    //                    VacantId = pickContactVacantBindingContext.Id,
    //                    EmployeeId = employee.Id
    //                });

    //                return await ocupationsAPIConnectClient.GetAsync(newOcupationId);
    //            }).ContinueWith(_task =>
    //            {
    //                Dispatcher.Dispatch(() =>
    //                {
    //                    if (_task.Exception != null || _task.IsCanceled)
    //                    {
    //                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(_task.Exception, this);
    //                    }
    //                    else
    //                    {
    //                        pickContactVacantBindingContext.Ocupation = _task.Result;
    //                    }

    //                    pickContactVacantBindingContext = null;

    //                    ConcreteBindingContext.IsBusy = false;
    //                });
    //            });
    //        });
    //    });
    //}
}