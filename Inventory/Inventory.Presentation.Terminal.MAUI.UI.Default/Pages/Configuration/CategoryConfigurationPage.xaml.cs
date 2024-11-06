using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CategoryConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.CategoryDisplayModel>
{
    public CategoryConfigurationPage(System.Action<Interop.API.Common.Models.Display.CategoryDisplayModel> successAction, Models.Page.Configuration.CategoryConfigurationPageModel model) : base(successAction, model)
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

    protected override string EntityTypeName => "Categoría";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CategoryDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CategoryConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CategoryInputModel
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

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CategoryDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CategoriesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.CategoryConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.CategoryInputModel
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
