using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class StaffConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<StaffDisplayModel>
{
    public StaffConfigurationPage(System.Action<StaffDisplayModel> successAction, Models.Page.Configuration.StaffConfigurationPageModel model) : base(successAction, model)
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

    protected override async System.Threading.Tasks.Task<StaffDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.StaffConfigurationPageModel)BindingContext;

        var model = new StaffInputModel
        {
            Id = System.Guid.NewGuid(),
            StructureId = concreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            MainWorkforceId = concreteBindingContext.AvailableWorkforces[MainWorkforcePicker.SelectedIndex].Id,
            AlternativeWorkforces = concreteBindingContext.AlternativeWorkforceBridges.ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<StaffDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.StaffsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.StaffConfigurationPageModel)BindingContext;

        var model = new StaffInputModel
        {
            Id = concreteBindingContext.Id,
            StructureId = concreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            MainWorkforceId = concreteBindingContext.AvailableWorkforces[MainWorkforcePicker.SelectedIndex].Id,
            AlternativeWorkforces = concreteBindingContext.AlternativeWorkforceBridges.ToArray()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}