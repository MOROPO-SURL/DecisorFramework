using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OrganizationalUnityConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel, Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel, Models.Page.Configuration.OrganizationalUnityConfigurationPageModel>
{
    public OrganizationalUnityConfigurationPage(System.Action<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> successAction, Models.Page.Configuration.OrganizationalUnityConfigurationPageModel model) : base(successAction, model, new Validators.OrganizationalUnityConfigurationValidator())
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

        var model = new Interop.API.Common.Models.Input.OrganizationalUnityInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            ParentId = ConcreteBindingContext.Parent?.Id,
            Reference = ConcreteBindingContext.Reference,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ParentalOrganizationalUnitiesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OrganizationalUnityInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            ParentId = ConcreteBindingContext.Parent?.Id,
            Reference = ConcreteBindingContext.Reference,
            Priority = ConcreteBindingContext.Priority
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

    private void ClearParentButton_Clicked(object sender, System.EventArgs e)
    {
        ConcreteBindingContext.Parent = null;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}