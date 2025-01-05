using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OrganizationalUnityConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel>
{
    public OrganizationalUnityConfigurationPage(System.Action<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> successAction, Models.Page.Configuration.OrganizationalUnityConfigurationPageModel model) : base(successAction, model)
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

    protected override string EntityTypeName => "Unidad Organizativa";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.OrganizationalUnityConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.OrganizationalUnityInputModel
        {
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Reference = concreteBindingContext.Reference,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.OrganizationalUnityConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.OrganizationalUnityInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Reference = concreteBindingContext.Reference,
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