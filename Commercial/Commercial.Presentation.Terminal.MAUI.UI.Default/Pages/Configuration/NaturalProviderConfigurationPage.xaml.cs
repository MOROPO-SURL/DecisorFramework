using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalProviderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<Interop.API.Common.Models.Display.NaturalProviderDisplayModel>
{
    public NaturalProviderConfigurationPage(System.Action<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> successAction, Models.Page.Configuration.NaturalProviderConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Proveedor Natural";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.NaturalProviderInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = concreteBindingContext.Contact.Id,
            Priority = concreteBindingContext.Priority,
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalProviderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalProvidersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.NaturalProviderInputModel
        {
            Id = concreteBindingContext.Id,
            ContactId = concreteBindingContext.Contact.Id,
            Priority = concreteBindingContext.Priority,
            PersonalIdentificationNumber = concreteBindingContext.PersonalIdentificationNumber
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.NaturalProviderConfigurationPageModel)BindingContext;

        concreteBindingContext.Contact = model;
    }
}