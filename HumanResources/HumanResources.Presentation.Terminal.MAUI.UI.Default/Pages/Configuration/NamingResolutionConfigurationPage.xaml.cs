using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NamingResolutionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Interop.API.Common.Models.Display.NamingResolutionDisplayModel, Models.Page.Configuration.NamingResolutionConfigurationPageModel>
{
    public NamingResolutionConfigurationPage(System.Action<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> successAction, Models.Page.Configuration.NamingResolutionConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resolución de Nombramiento";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ContactId = ConcreteBindingContext.Contact?.Id,
            VacantId = ConcreteBindingContext.Vacant?.Id,
            StaffId = ConcreteBindingContext.Staff?.Id,
            CandidateId = ConcreteBindingContext.Candidate?.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.NamingResolutionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NamingResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.NamingResolutionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ContactId = ConcreteBindingContext.Contact?.Id,
            VacantId = ConcreteBindingContext.Vacant?.Id,
            StaffId = ConcreteBindingContext.Staff?.Id,
            CandidateId = ConcreteBindingContext.Candidate?.Id
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

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void VacantPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.VacantPickPage([Persistence.Enumerations.VacantOcupationMode.Naming], VacantPickComplete_Callback)));
    }

    private void CandidatePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OcupationCandidatePickPage(true, CondidatePickComplete_Callback)));
    }

    private void CondidatePickComplete_Callback(Interop.API.Common.Models.Display.OcupationCandidateDisplayModel model)
    {
        ConcreteBindingContext.Candidate = model;
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.NamingResolutionConfigurationPageModel)BindingContext;

        concreteBindingContext.Contact = model;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;
    }

    private void VacantPickComplete_Callback(Models.View.StaffVacantViewModel model)
    {
        ConcreteBindingContext.Staff = model.Staff;
        ConcreteBindingContext.Vacant = model.Vacant;
    }
}