using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkPositionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel>
{
    public WorkPositionConfigurationPage(System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> successAction, Models.Page.Configuration.WorkPositionConfigurationPageModel model) : base(successAction, model, null)
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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkPositionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkPositionInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            SchoolingId = ConcreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkPositionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkPositionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkPositionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            KindId = ConcreteBindingContext.AvailableKinds[KindPicker.SelectedIndex].Id,
            SchoolingId = ConcreteBindingContext.AvailableSchoolings[SchoolingPicker.SelectedIndex].Id,
            Reference = ConcreteBindingContext.Reference,
            Description = ConcreteBindingContext.Description
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