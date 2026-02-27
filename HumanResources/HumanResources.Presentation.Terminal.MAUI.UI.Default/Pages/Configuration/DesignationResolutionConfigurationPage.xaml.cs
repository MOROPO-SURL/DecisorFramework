using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DesignationResolutionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, Models.Page.Configuration.DesignationResolutionConfigurationPageModel>
{
    public DesignationResolutionConfigurationPage(System.Action<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel> successAction, Models.Page.Configuration.DesignationResolutionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.DesignationResolutionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resolución de Designación";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DesignationResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.DesignationResolutionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement?.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            VacantId = ConcreteBindingContext.Vacant.Id,
            StaffId = ConcreteBindingContext.Staff.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DesignationResolutionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.DesignationResolutionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.At,
            Summary = ConcreteBindingContext.Summary,
            AgreementId = ConcreteBindingContext.Agreement?.Id,
            ContactId = ConcreteBindingContext.Contact.Id,
            VacantId = ConcreteBindingContext.Vacant.Id,
            StaffId = ConcreteBindingContext.Staff.Id
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.VacantPickPage([Persistence.Enumerations.VacantOcupationMode.Designation], VacantPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.DesignationResolutionConfigurationPageModel)BindingContext;

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