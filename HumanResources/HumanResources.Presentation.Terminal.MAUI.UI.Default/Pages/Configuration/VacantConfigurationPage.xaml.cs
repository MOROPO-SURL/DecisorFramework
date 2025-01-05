using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VacantConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.VacantDisplayModel>
{
    public VacantConfigurationPage(System.Action<Interop.API.Common.Models.Display.VacantDisplayModel> successAction, Models.Page.Configuration.VacantConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Kind != null)
        {
            for (int i = 0; i < model.AvailableKinds.Length; i++)
            {
                var current = model.AvailableKinds[i];

                if (model.Kind.Id != current.Id) continue;

                KindPicker.SelectedIndex = i;
                KindPicker.SelectedItem = current;

                break;
            }
        }

        if (model.Schooling != null)
        {
            for (int i = 0; i < model.AvailableSchoolings.Length; i++)
            {
                var current = model.AvailableSchoolings[i];

                if (model.Schooling.Id != current.Id) continue;

                SchoolingPicker.SelectedIndex = i;
                SchoolingPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Plaza Laboral";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.VacantDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VacantsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.VacantConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.VacantInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            KindId = concreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            SchoolingId = concreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            Reference = concreteBindingContext.Reference,
            Description = concreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.VacantDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VacantsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.VacantConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.VacantInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            KindId = concreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            SchoolingId = concreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            Reference = concreteBindingContext.Reference,
            Description = concreteBindingContext.Description
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}