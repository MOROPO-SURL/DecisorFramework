using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientSampleAnalysisServiceOrderConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
	public LegalClientSampleAnalysisServiceOrderConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel> successAction, Models.Page.Configuration.LegalClientSampleAnalysisServiceOrderConfigurationPageModel model, Validators.LegalClientSampleAnalysisServiceOrderConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Órden de Servicio para Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientSampleAnalysisServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientSampleAnalysisServiceOrderInputModel
        {
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description,
            RequestedTechniqueId = ConcreteBindingContext.RequestedTechnique?.Id
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientSampleAnalysisServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientSampleAnalysisServiceOrderInputModel
        {
            Id = ConcreteBindingContext.Id,
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description,
            RequestedTechniqueId = ConcreteBindingContext.RequestedTechnique?.Id
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.SampleAnalysisServicePickPage(ServicePickComplete_Callback)));
    }

    private void TechniquePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.TechniquePickPage(TechniquePickComplete_Callback)));
    }

    private void ContractPickComplete_Callback(Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel model)
    {
        ConcreteBindingContext.Contract = model;

        hasChangesFlag = true;
    }

    private void ServicePickComplete_Callback(Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel model)
    {
        ConcreteBindingContext.Service = model;

        hasChangesFlag = true;
    }

    private void TechniquePickComplete_Callback(Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel model)
    {
        ConcreteBindingContext.RequestedTechnique = model;

        hasChangesFlag = true;
    }
}