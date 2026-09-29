using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ScientificTechnicalResultConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ScientificTechnicalResultDisplayModel, ScientificTechnicalResultDisplayModel, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel>
{
    public ScientificTechnicalResultConfigurationPage(System.Action<ScientificTechnicalResultDisplayModel> successAction, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel model, Validators.ScientificTechnicalResultConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resultado CTI";

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.Kind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.Kind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id
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

    private void ProjectPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProjectPickPage(ProjectPickComplete_Callback)));
    }

    private void ProjectPickComplete_Callback(ProjectDisplayModel model)
    {
        ConcreteBindingContext.Project = model;
    }
}