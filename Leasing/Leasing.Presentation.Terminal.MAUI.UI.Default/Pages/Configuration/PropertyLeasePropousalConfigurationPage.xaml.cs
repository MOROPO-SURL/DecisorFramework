using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PropertyLeasePropousalConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<PropertyLeasePropousalDisplayModel, PropertyLeasePropousalDisplayModel, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel>
{
    public PropertyLeasePropousalConfigurationPage(System.Action<PropertyLeasePropousalDisplayModel> successAction, Models.Page.Configuration.PropertyLeasePropousalConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Propuesta de Arrendamiento de Inmueble";

    protected async override System.Threading.Tasks.Task<PropertyLeasePropousalDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyLeasePropousalInputModel
        {
            Id = System.Guid.NewGuid(),
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            PropertyId = ConcreteBindingContext.Property.Id,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<PropertyLeasePropousalDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PropertyLeasePropousalsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PropertyLeasePropousalInputModel
        {
            Id = ConcreteBindingContext.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            PropertyId = ConcreteBindingContext.Property.Id,
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

    private void PropertyPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PropertyPickPage(PropertyPickComplete_Callback, new Domain.Interop.API.Common.Models.Filter.PropertyFilterModel { Assignments = [] })));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void PropertyPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PropertyDisplayModel model)
    {
        ConcreteBindingContext.Property = model;
    }

    private void AuthorPickComplete_Callback(HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }
}