using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalProviderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.LegalProviderDisplayModel>
{
    public LegalProviderConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalProviderDisplayModel> successAction, Models.Page.Configuration.LegalProviderConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proveedor Jurídico";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalProviderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.LegalProviderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.LegalProviderInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = concreteBindingContext.Contact.Id,
            TaxIdentificationNumber = concreteBindingContext.TaxIdentificationNumber,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalProviderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.LegalProviderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.LegalProviderInputModel
        {
            Id = concreteBindingContext.Id,
            ContactId = concreteBindingContext.Contact.Id,
            TaxIdentificationNumber = concreteBindingContext.TaxIdentificationNumber,
            Priority = concreteBindingContext.Priority
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.LegalProviderConfigurationPageModel)BindingContext;

        concreteBindingContext.Contact = model;
    }
}