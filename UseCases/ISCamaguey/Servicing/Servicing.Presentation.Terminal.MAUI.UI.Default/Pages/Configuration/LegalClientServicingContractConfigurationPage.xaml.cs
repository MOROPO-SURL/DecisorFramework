using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class LegalClientServicingContractConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel>
{
	public LegalClientServicingContractConfigurationPage(System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> successAction, Models.Page.Configuration.LegalClientServicingContractConfigurationPageModel model, Validators.LegalClientServicingContractConfigurationValidator validator) : base(successAction, model, validator)
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Contrato de Servicios a Cliente Jurídico";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientServicingContractsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientServicingContractInputModel
        {
            Id = ConcreteBindingContext.Id,
            Year = ConcreteBindingContext.Year,
            Objective = ConcreteBindingContext.Objective,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            PaymentTermId = ConcreteBindingContext.PaymentTerm.Id,
            ClientId = ConcreteBindingContext.Client.Id,
            BankAccountId = ConcreteBindingContext.BanckAccount.Id,
            TrainingServices = [.. ConcreteBindingContext.TrainingServices],
            SampleAnalysisServices = [.. ConcreteBindingContext.SampleAnalysisServices],
            GroundIntegralStudyServices = [.. ConcreteBindingContext.GroundIntegralStudyServices]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.LegalClientServicingContractsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.LegalClientServicingContractInputModel
        {
            Id = ConcreteBindingContext.Id,
            Year = ConcreteBindingContext.Year,
            Objective = ConcreteBindingContext.Objective,
            DurationUnitCount = ConcreteBindingContext.DurationUnitCount,
            DurationUnitMeasureKind = ConcreteBindingContext.DurationUnitMeasureKind,
            PaymentTermId = ConcreteBindingContext.PaymentTerm.Id,
            ClientId = ConcreteBindingContext.Client.Id,
            BankAccountId = ConcreteBindingContext.BanckAccount.Id,
            TrainingServices = [.. ConcreteBindingContext.TrainingServices],
            SampleAnalysisServices = [.. ConcreteBindingContext.SampleAnalysisServices],
            GroundIntegralStudyServices = [.. ConcreteBindingContext.GroundIntegralStudyServices]
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
}