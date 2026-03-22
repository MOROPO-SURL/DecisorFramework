using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages.Configuration;

public partial class SimplifiedStaffConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel, Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel>
{
    public SimplifiedStaffConfigurationPage(System.Action<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel> successAction, Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel model, FluentValidation.AbstractValidator<Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration.StaffConfigurationPageModel> validator) : base(successAction, model, validator)
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

    protected override async System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Framework.Decisor.HumanResources.Interop.API.Common.Models.Input.StaffInputModel
        {
            Id = System.Guid.NewGuid(),
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            MainWorkforceId = ConcreteBindingContext.MainWorkforce.Id,
            WorkingWeekHourCount = ConcreteBindingContext.WorkingWeekHourCount,
            DoctorateExtraFeed = ConcreteBindingContext.DoctorateExtraFeed,
            MasteryExtraFeed = ConcreteBindingContext.MasteryExtraFeed,
            AlternativeWorkforces = [.. ConcreteBindingContext.AlternativeWorkforceBridges]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.StaffDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Framework.Decisor.HumanResources.Interop.API.Common.Models.Input.StaffInputModel
        {
            Id = ConcreteBindingContext.Id,
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            MainWorkforceId = ConcreteBindingContext.MainWorkforce.Id,
            WorkingWeekHourCount = ConcreteBindingContext.WorkingWeekHourCount,
            DoctorateExtraFeed = ConcreteBindingContext.DoctorateExtraFeed,
            MasteryExtraFeed = ConcreteBindingContext.MasteryExtraFeed,
            AlternativeWorkforces = [.. ConcreteBindingContext.AlternativeWorkforceBridges]
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

        var workforcesAPIConnectClient = new Framework.Decisor.HumanResources.Interop.API.Connect.Clients.WorkforcesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        workforcesAPIConnectClient.FilterAsync(new Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter.WorkforceFilterModel { OrganizationalStructure = ConcreteBindingContext.AdministrativeEntity.OrganizationalStructure }).ContinueWith(task =>
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
}