using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class FamilyConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.FamilyDisplayModel, Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel>
{
    public FamilyConfigurationPage(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> successAction, Models.Page.Configuration.FamilyConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Parent != null)
        {
            for (int i = 0; i < model.AvailableParents.Length; i++)
            {
                var current = model.AvailableParents[i];

                if (model.Parent.Id != current.Id) continue;

                ParentPicker.SelectedIndex = i;
                ParentPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Familia de Productos";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.FamilyDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Name = ConcreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        // TODO Try to recover added Category
        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.FamilyDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
