using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class OcupationByAdmistionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<OcupationDisplayModel, OcupationDisplayModel, Models.Page.Configuration.OcupationByAdmisionConfigurationPageModel>
{
    public OcupationByAdmistionConfigurationPage(System.Action<OcupationDisplayModel> successAction, Models.Page.Configuration.OcupationByAdmisionConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();

        hasChangesFlag = true;
    }

    protected override string EntityTypeName => "Ocupación por Admisión";

    protected override async System.Threading.Tasks.Task<OcupationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.OcupationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new OcupationInputModel
        {
            Id = System.Guid.NewGuid(),
            AdmisionPropousalId = ConcreteBindingContext.AdmitionPropousal.Id,
            StarAt = ConcreteBindingContext.StartAt,
            DurationUnitCount = ConcreteBindingContext.IsDetermiteDuration ? ConcreteBindingContext.Duration : null,
            DurationUnitMeasureKind = ConcreteBindingContext.IsDetermiteDuration ? ConcreteBindingContext.DurationUnitMeasureKind : null
        };

        await apiConnectClient.CreateAsync(model);

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