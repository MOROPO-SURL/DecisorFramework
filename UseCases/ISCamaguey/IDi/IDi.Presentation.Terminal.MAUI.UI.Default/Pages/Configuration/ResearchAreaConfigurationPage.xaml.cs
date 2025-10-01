using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ResearchAreaConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ResearchAreaDisplayModel, Interop.API.Common.Models.Display.ResearchAreaDisplayModel, Models.Page.Configuration.ResearchAreaConfigurationPageModel>
{
    public ResearchAreaConfigurationPage(System.Action<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> successAction, Models.Page.Configuration.ResearchAreaConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ResearchAreaConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Área de Investigación";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ResearchAreasAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ResearchAreaInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ResearchAreaDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ResearchAreasAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ResearchAreaInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
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
}