using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class EmployeeConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>
{
    public EmployeeConfigurationPage(System.Action<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> successAction, Models.Page.Configuration.EmployeeConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Trabajador";

    protected override async System.Threading.Tasks.Task<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.EmployeeConfigurationPageModel)BindingContext;

        var model = new Domain.Interop.API.Common.Models.Input.EmployeeInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = concreteBindingContext.Contact.Id,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Domain.Interop.API.Connect.Clients.EmployeesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.EmployeeConfigurationPageModel)BindingContext;

        var model = new Domain.Interop.API.Common.Models.Input.EmployeeInputModel
        {
            Id = concreteBindingContext.Id,
            ContactId = concreteBindingContext.Contact.Id,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(PersonContactDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.EmployeeConfigurationPageModel)BindingContext;

        concreteBindingContext.Contact = model;
    }
}