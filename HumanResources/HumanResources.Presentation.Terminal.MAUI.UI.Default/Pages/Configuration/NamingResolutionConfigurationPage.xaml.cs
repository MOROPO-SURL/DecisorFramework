using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NamingResolutionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel>
{
    public NamingResolutionConfigurationPage(System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> successAction, Models.Page.Configuration.NamingResolutionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resolución de Nombramiento";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.NamingResolutionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = concreteBindingContext.Id,
            At = concreteBindingContext.At,
            Summary = concreteBindingContext.Summary,
            NamedEmployeeId = concreteBindingContext.NamedEmployee.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.NamingResolutionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = concreteBindingContext.Id,
            At = concreteBindingContext.At,
            Summary = concreteBindingContext.Summary,
            NamedEmployeeId = concreteBindingContext.NamedEmployee.Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void NamedEmployeePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.EmployeePickPage(NamedEmployeePickComplete_Callback)));
    }

    private void NamedEmployeePickComplete_Callback(Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.NamingResolutionConfigurationPageModel)BindingContext;

        concreteBindingContext.NamedEmployee = model;
    }
}