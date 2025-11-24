using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientSampleAnalysisServiceOrderConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel>
{
    public NaturalClientSampleAnalysisServiceOrderConfigurationPage(System.Action<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel> successAction, Models.Page.Configuration.NaturalClientSampleAnalysisServiceOrderConfigurationPageModel model, Validators.NaturalClientSampleAnalysisServiceOrderConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Órden de Servicio para Cliente Natural";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientSampleAnalysisServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientSampleAnalysisServiceOrderInputModel
        {
            ContractId = ConcreteBindingContext.Contract.Id,
            ServiceId = ConcreteBindingContext.Service.Id,
            Description = ConcreteBindingContext.Description,
            RequestedTechniqueId = ConcreteBindingContext.RequestedTechnique?.Id
        };

        await apiConnectClient.CreateAsync(model);

        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientSampleAnalysisServiceOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NaturalClientSampleAnalysisServiceOrderInputModel
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalClientServicingContractPickPage(ContractPickComplete_Callback)));
    }

    private void ServicePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.SampleAnalysisServicePickPage(ServicePickComplete_Callback)));
    }

    private void TechniquePickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.TechniquePickPage(TechniquePickComplete_Callback)));
    }

    private void ContractPickComplete_Callback(Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel model)
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