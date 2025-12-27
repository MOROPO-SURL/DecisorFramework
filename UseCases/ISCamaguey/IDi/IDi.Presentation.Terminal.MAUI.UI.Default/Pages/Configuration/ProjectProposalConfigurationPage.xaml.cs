using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProjectProposalConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Interop.API.Common.Models.Display.ProjectProposalDisplayModel, Models.Page.Configuration.ProjectProposalConfigurationPageModel>
{
    public ProjectProposalConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> successAction, Models.Page.Configuration.ProjectProposalConfigurationPageModel model, Validators.ProjectProposalConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Propuesta de Proyecto";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectProposalInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ProgramId = ConcreteBindingContext.Program?.Id,
            CallForPropousalId = ConcreteBindingContext.CallForPropousal?.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectProposalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectProposalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectProposalInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ProgramId = ConcreteBindingContext.Program?.Id,
            CallForPropousalId = ConcreteBindingContext.CallForPropousal?.Id
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

    private void ProgramPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProgramPickPage(ProgramPickComplete_Callback)));
    }

    private void CallForPropousalPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.CallForProposalPickPage(CallForPropousalPickComplete_Callback)));
    }

    private void ProgramPickComplete_Callback(Interop.API.Common.Models.Display.ProgramDisplayModel model)
    {
        ConcreteBindingContext.Program = model;
    }

    private void CallForPropousalPickComplete_Callback(Interop.API.Common.Models.Display.CallForProposalDisplayModel model)
    {
        ConcreteBindingContext.CallForPropousal = model;
    }
}