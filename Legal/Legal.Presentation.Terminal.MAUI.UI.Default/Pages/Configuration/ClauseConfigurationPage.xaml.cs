using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ClauseConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ClauseDisplayModel, ClauseDisplayModel, Models.Page.Configuration.ClauseConfigurationPageModel>
{
    public ClauseConfigurationPage(System.Action<ClauseDisplayModel> successAction, Models.Page.Configuration.ClauseConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Cláusula Contractual";

    protected override async System.Threading.Tasks.Task<ClauseDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ClausesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ClauseInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            Content = ConcreteBindingContext.Content
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ClauseDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ClausesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ClauseInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Priority = ConcreteBindingContext.Priority,
            Content = ConcreteBindingContext.Content
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