using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientGroundIntegralStudyServiceOrderConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel>
{
	public NaturalClientGroundIntegralStudyServiceOrderConfigurationPage(System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel> successAction, Models.Page.Configuration.NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel model, Validators.NaturalClientGroundIntegralStudyServiceOrderConfigurationValidator validator) : base(successAction, model, validator)
    {
		InitializeComponent();
	}
    protected override string EntityTypeName => "Órden de Servicio para Cliente Natural";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientGroundIntegralStudyServiceOrderInputModel
        {
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientGroundIntegralStudyServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientGroundIntegralStudyServiceOrderInputModel
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalClientServicingContractPickPage(ContractPickComplete_Callback)));
    }

    private void ServicePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.GroundIntegralStudyServicePickPage(ServicePickComplete_Callback)));
    }

    private void ContractPickComplete_Callback(Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel model)
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