using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class VehicleLeaseOfferConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<VehicleLeaseOfferDisplayModel, VehicleLeaseOfferDisplayModel, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel>
{
    public VehicleLeaseOfferConfigurationPage(System.Action<VehicleLeaseOfferDisplayModel> successAction, Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Oferta de Arrendamiento de Vehículo";

    protected async override System.Threading.Tasks.Task<VehicleLeaseOfferDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.VehicleLeaseOfferInputModel
        {
            Id = System.Guid.NewGuid(),
            PropousalId = ConcreteBindingContext.Propousal.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            OpenAt = ConcreteBindingContext.OpenAt,
            ClosedAt = ConcreteBindingContext.HasClosetAtDate ? ConcreteBindingContext.ClosedAt : null,
            Priority = ConcreteBindingContext.Priority
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<VehicleLeaseOfferDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.VehicleLeaseOffersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.VehicleLeaseOfferInputModel
        {
            Id = concreteBindingContext.Id,
            PropousalId = ConcreteBindingContext.Propousal.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            Description = ConcreteBindingContext.Description,
            OpenAt = ConcreteBindingContext.OpenAt,
            ClosedAt = ConcreteBindingContext.HasClosetAtDate ? ConcreteBindingContext.ClosedAt : null,
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
    private void PropousalPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.VehicleLeasePropousalPickPage(PropousalPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void PropousalPickComplete_Callback(VehicleLeasePropousalDisplayModel model)
    {
        ConcreteBindingContext.Propousal = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }
}