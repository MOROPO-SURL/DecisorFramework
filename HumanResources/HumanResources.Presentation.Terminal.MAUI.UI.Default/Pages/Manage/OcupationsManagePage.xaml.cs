using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Manage;

public partial class OcupationsManagePage : Caney.MVVM.Core.Pages.ContentPage
{
    private Models.View.OcupationsManageVacantViewModel pickContactVacantBindingContext;

	public OcupationsManagePage()
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
        ConcreteBindingContext.RootTreeOcupationManageOrganizationalStructuringUnit = null;

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

        System.Threading.Tasks.Task.Run(async () => 
        {
            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

            var workforceAPIConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(httpClientHelperProvider);
            var ocupationsAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(httpClientHelperProvider);

            var targetWorkforce = await workforceAPIConnectClient.GetAsync(targetWorkforceId);

            var ocupations = new System.Collections.Generic.List<Interop.API.Common.Models.Display.OcupationDisplayModel>(await ocupationsAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.OcupationFilterModel { StaffId = staffId, WorkforceId = targetWorkforceId }));

            return targetWorkforce.OrganizationalStructure.RootStructuringUnit.ToConfigurationTreeViewModel([.. targetWorkforce.OrganizationalUnits], ocupations, null);
        }).ContinueWith(task => 
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                }
                else
                {
                    ConcreteBindingContext.RootTreeOcupationManageOrganizationalStructuringUnit = task.Result;
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void LeafOcupationCreationButton_Clicked(object sender, System.EventArgs e)
    {
        pickContactVacantBindingContext = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsManageVacantViewModel;

        if (pickContactVacantBindingContext.VacantOcupationMode == Persistence.Enumerations.VacantOcupationMode.Designation)
        {
            ConcreteBindingContext.IsBusy = true;

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

            var designationResolutionAPIConnectClient = new Interop.API.Connect.Clients.DesignationResolutionsAPIConnectClient(httpClientHelperProvider);

            designationResolutionAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.DesignationResolutionFilterModel { WorkPositionId = pickContactVacantBindingContext.WorkPosition.Id, StaffId = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex].Id }).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }
                    else
                    {
                        var availables = task.Result.Where(model => model.ConcretedAt == null).ToArray();

                        if (availables.Length <= 0)
                        {
                            ConcreteBindingContext.IsBusy = false;

                            DisplayAlert("Aviso", "No existen resoluciones de designación vigentes relacionadas con la vacante seleccionada.", "Aceptar");
                        }
                        else
                        {
                            DisplayAlert("Confirmación", "Está seguro que desea aplicar la resolución de designación vigente vinculada a esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(_task =>
                            {
                                if (!_task.Result)
                                {
                                    Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = false);

                                    return;
                                }

                                System.Threading.Tasks.Task.Run(async () =>
                                {
                                    var ocupationAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                                    var ocupationId = System.Guid.NewGuid();

                                    await ocupationAPIConnectClient.CreateAsync(new Interop.API.Common.Models.Input.OcupationInputModel
                                    {
                                        Id = ocupationId,
                                        StarAt = System.DateTime.Now,
                                        OcupationMode = pickContactVacantBindingContext.VacantOcupationMode,
                                        ResolutionId = availables[0].Id
                                    });

                                    return await ocupationAPIConnectClient.GetAsync(ocupationId);
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

                                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
                                        }

                                        pickContactVacantBindingContext = null;

                                        ConcreteBindingContext.IsBusy = false;
                                    });
                                });
                            });
                        }
                    }
                });
            });

            return;
        }
        
        if (pickContactVacantBindingContext.VacantOcupationMode == Persistence.Enumerations.VacantOcupationMode.Naming)
        {
            ConcreteBindingContext.IsBusy = true;

            var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>();

            var namingResolutionAPIConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(httpClientHelperProvider);

            namingResolutionAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.NamingResolutionFilterModel { WorkPositionId = pickContactVacantBindingContext.WorkPosition.Id, StaffId = ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex].Id }).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (task.Exception != null || task.IsCanceled)
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }
                    else
                    {
                        var availables = task.Result.Where(model => model.ConcretedAt == null).ToArray();

                        if (availables.Length <= 0)
                        {
                            ConcreteBindingContext.IsBusy = false;

                            DisplayAlert("Aviso", "No existen resoluciones de nombramiento vigentes relacionadas con la vacante seleccionada.", "Aceptar");
                        }
                        else
                        {
                            DisplayAlert("Confirmación", "Está seguro que desea aplicar la resolución de nombramiento vigente vinculada a esta ocupación en la plantilla?", "Confirmar", "Cancelar").ContinueWith(_task =>
                            {
                                if (!_task.Result)
                                {
                                    Dispatcher.Dispatch(() => ConcreteBindingContext.IsBusy = false);

                                    return;
                                }

                                System.Threading.Tasks.Task.Run(async () =>
                                {
                                    var ocupationAPIConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                                    var ocupationId = System.Guid.NewGuid();

                                    await ocupationAPIConnectClient.CreateAsync(new Interop.API.Common.Models.Input.OcupationInputModel
                                    {
                                        Id = ocupationId,
                                        StarAt = System.DateTime.Now,
                                        OcupationMode = pickContactVacantBindingContext.VacantOcupationMode,
                                        ResolutionId = availables[0].Id
                                    });

                                    return await ocupationAPIConnectClient.GetAsync(ocupationId);
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

                                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Cambios aplicados con éxito.");
                                        }

                                        pickContactVacantBindingContext = null;

                                        ConcreteBindingContext.IsBusy = false;
                                    });
                                });
                            });
                        }
                    }
                });
            });

            return;
        }
        
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.AdmitionPropousalPickPage(AdmitionPropousalPickComplete_Callback, pickContactVacantBindingContext.WorkPosition, ConcreteBindingContext.AvailableStaffs[StaffPicker.SelectedIndex])));
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

                var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsManageVacantViewModel;

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

                            this.PresentToastNotification(Core.Presentation.Terminal.MAUI.Enumerations.NotificationKind.Success, "Persona asignada a la ocupación retirada con éxito.");
                        }

                        ConcreteBindingContext.IsBusy = false;
                    });
                });
            });
        });
    }

    private void LeafEmployeeDetailButton_Clicked(object sender, System.EventArgs e)
    {
        var model = (sender as Microsoft.Maui.Controls.BindableObject).BindingContext as Models.View.OcupationsManageVacantViewModel;

        var employeesAPIConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;
        
        employeesAPIConnectClient.GetAsync(model.Ocupation.Employee.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<EmployeeDisplayModel>>();

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

    private void AdmitionPropousalPickComplete_Callback(Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel model)
    {
        Dispatcher.Dispatch(() => this.NavigationPushPageAsync(new Configuration.OcupationByAdmistionConfigurationPage(OcupationConfigurationComplete_Callback, new Models.Page.Configuration.OcupationByAdmisionConfigurationPageModel(model, null))));
    }

    private void OcupationConfigurationComplete_Callback(Interop.API.Common.Models.Display.OcupationDisplayModel model)
    {
        pickContactVacantBindingContext.Ocupation = model;
                                        
        pickContactVacantBindingContext = null;
    }
}