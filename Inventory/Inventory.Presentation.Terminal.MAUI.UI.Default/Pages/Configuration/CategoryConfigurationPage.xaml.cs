using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CategoryConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.FamilyDisplayModel>
{
    public CategoryConfigurationPage(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> successAction, Models.Page.Configuration.CategoryConfigurationPageModel model) : base(successAction, model)
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

        var concreteBindingContext = (Models.Page.Configuration.CategoryConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        // TODO Try to recover added Category
        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.FamilyDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CategoryConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}
