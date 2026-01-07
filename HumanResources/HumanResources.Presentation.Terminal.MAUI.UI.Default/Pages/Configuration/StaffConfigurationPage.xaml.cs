using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class StaffConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.StaffDisplayModel, Interop.API.Common.Models.Display.StaffDisplayModel, Models.Page.Configuration.StaffConfigurationPageModel>
{
    public StaffConfigurationPage(System.Action<Interop.API.Common.Models.Display.StaffDisplayModel> successAction, Models.Page.Configuration.StaffConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.StaffConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Structure != null)
        {
            for (int i = 0; i < model.AvailableStructures.Length; i++)
            {
                var current = model.AvailableStructures[i];

                if (model.Structure.Id != current.Id) continue;

                StructurePicker.SelectedIndex = i;
                StructurePicker.SelectedItem = current;

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
                MainWorkforcePicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Asignación de Plantilla";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.StaffDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.StaffInputModel
        {
            Id = System.Guid.NewGuid(),
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            MainWorkforceId = ConcreteBindingContext.AvailableWorkforces[MainWorkforcePicker.SelectedIndex].Id,
            WorkingDayCount = ConcreteBindingContext.WorkingDayCount,
            AlternativeWorkforces = [.. ConcreteBindingContext.AlternativeWorkforceBridges]
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
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            MainWorkforceId = ConcreteBindingContext.AvailableWorkforces[MainWorkforcePicker.SelectedIndex].Id,
            WorkingDayCount = ConcreteBindingContext.WorkingDayCount,
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}