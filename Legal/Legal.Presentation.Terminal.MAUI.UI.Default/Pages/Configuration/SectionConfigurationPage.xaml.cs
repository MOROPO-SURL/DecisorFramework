using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class SectionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel>
{
    public SectionConfigurationPage(System.Action<SectionDisplayModel> successAction, Models.Page.Configuration.SectionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Parent != null)
        {
            for (int i = 0; i < model.AvailableParents.Length; i++)
            {
                var current = model.AvailableParents[i];

                if (model.Parent.Id != current.Id) continue;

                ParentPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Sección Contractual";

    protected override async System.Threading.Tasks.Task<SectionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SectionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.SectionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.SectionInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<SectionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SectionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.SectionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.SectionInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
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