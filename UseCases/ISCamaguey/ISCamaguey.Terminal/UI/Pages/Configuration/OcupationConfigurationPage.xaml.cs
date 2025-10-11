using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Terminal.UI.Pages.Configuration;

public partial class OcupationConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel, Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel, Models.Page.Configuration.OcupationConfigurationPageModel>
{
    public OcupationConfigurationPage(System.Action<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel> successAction, Models.Page.Configuration.OcupationConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Ocupación Simplificada";

    protected override async System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.OcupationInputModel
        {
            Id = System.Guid.NewGuid(),
            ContactId = ConcreteBindingContext.Contact.Id,
            VacantId = ConcreteBindingContext.Vacant.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            StaffId = ConcreteBindingContext.StaffId
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override System.Threading.Tasks.Task<Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.OcupationDisplayModel> PerformEditionAsync()
    {
        throw new System.InvalidOperationException();
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;
    }
}