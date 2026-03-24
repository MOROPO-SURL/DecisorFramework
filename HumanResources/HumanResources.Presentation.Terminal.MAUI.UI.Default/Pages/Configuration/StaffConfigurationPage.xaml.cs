using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class StaffConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.StaffDisplayModel, Interop.API.Common.Models.Display.StaffDisplayModel, Models.Page.Configuration.StaffConfigurationPageModel>
{
    public StaffConfigurationPage(System.Action<Interop.API.Common.Models.Display.StaffDisplayModel> successAction, Models.Page.Configuration.StaffConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.StaffConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.AdministrativeEntity != null)
        {
            for (int i = 0; i < model.AvailableAdministrativeEntities.Length; i++)
            {
                var current = model.AvailableAdministrativeEntities[i];

                if (model.AdministrativeEntity.Id != current.Id) continue;

                StructurePicker.SelectedIndex = i;

                break;
            }
        }

        if (model.MainWorkforce != null)
        {
            for (int i = 0; i < model.AvailableWorkforces.Count; i++)
            {
                var current = model.AvailableWorkforces[i];

                if (model.MainWorkforce.Id != current.Id) continue;

                MainWorkforcePicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Configuración de Plantilla";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.StaffDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.StaffInputModel
        {
            Id = System.Guid.NewGuid(),
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            MainWorkforceId = ConcreteBindingContext.MainWorkforce.Id,
            WorkingWeekHourCount = ConcreteBindingContext.WorkingWeekHourCount,
            DoctorateExtraFeed = ConcreteBindingContext.DoctorateExtraFeed,
            MasteryExtraFeed = ConcreteBindingContext.MasteryExtraFeed,
            AlternativeWorkforces = [.. ConcreteBindingContext.AlternativeWorkforceBridges],
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.StaffDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.StaffInputModel
        {
            Id = ConcreteBindingContext.Id,
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            MainWorkforceId = ConcreteBindingContext.MainWorkforce.Id,
            WorkingWeekHourCount = ConcreteBindingContext.WorkingWeekHourCount,
            DoctorateExtraFeed = ConcreteBindingContext.DoctorateExtraFeed,
            MasteryExtraFeed = ConcreteBindingContext.MasteryExtraFeed,
            AlternativeWorkforces = [.. ConcreteBindingContext.AlternativeWorkforceBridges],
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void AdministrativeEntityPicker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;

        if (ConcreteBindingContext == null || ConcreteBindingContext.MainWorkforce != null) return;

        ConcreteBindingContext.IsBusy = true;

        var workforcesAPIConnectClient = new Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        workforcesAPIConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.WorkforceFilterModel { OrganizationalStructure = ConcreteBindingContext.AdministrativeEntity.OrganizationalStructure }).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    HandleException(task.Exception);
                }
                else
                {
                    ConcreteBindingContext.AvailableWorkforces.Clear();

                    foreach (var item in task.Result)
                    {
                        ConcreteBindingContext.AvailableWorkforces.Add(item);
                    }
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }
}