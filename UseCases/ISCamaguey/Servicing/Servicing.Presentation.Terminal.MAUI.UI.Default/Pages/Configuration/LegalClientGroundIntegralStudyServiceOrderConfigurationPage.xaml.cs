using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientGroundIntegralStudyServiceOrderConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
{
	public LegalClientGroundIntegralStudyServiceOrderConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel> successAction, Models.Page.Configuration.LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel model, Validators.LegalClientGroundIntegralStudyServiceOrderConfigurationValidator validator) : base(successAction, model, validator)
    {
		InitializeComponent();
	}
    protected override string EntityTypeName => "Órden de Servicio para Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientGroundIntegralStudyServiceOrderInputModel
        {
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientGroundIntegralStudyServiceOrderInputModel
        {
            Id = ConcreteBindingContext.Id,
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.EditAsync(model);

        return null;
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContractPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.LegalClientServicingContractPickPage(ContractPickComplete_Callback)));
    }

    private void ServicePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.GroundIntegralStudyServicePickPage(ServicePickComplete_Callback)));
    }

    private void ContractPickComplete_Callback(Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel model)
    {
        ConcreteBindingContext.Contract = model;

        hasChangesFlag = true;
    }

    private void ServicePickComplete_Callback(Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel model)
    {
        ConcreteBindingContext.Service = model;

        hasChangesFlag = true;
    }
}