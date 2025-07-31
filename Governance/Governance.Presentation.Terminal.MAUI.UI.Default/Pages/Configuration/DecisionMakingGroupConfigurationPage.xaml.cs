using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DecisionMakingGroupConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
{
    public DecisionMakingGroupConfigurationPage(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> successAction, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Grupo Decisor";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.DecisionMakingGroupInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            Fee = concreteBindingContext.Fee
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.DecisionMakingGroupInputModel
        {
            Id = concreteBindingContext.Id,
            Name = concreteBindingContext.Name,
            Priority = concreteBindingContext.Priority,
            Fee = concreteBindingContext.Fee
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