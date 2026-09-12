using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AssessmentQualityCheckConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<AssessmentQualityCheckDisplayModel, AssessmentQualityCheckDisplayModel, Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel>
{
	public AssessmentQualityCheckConfigurationPage(System.Action<AssessmentQualityCheckDisplayModel> successAction, Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.AssessmentQualityCheckConfigurationPageModel> validator) : base(successAction, model, validator)
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Evaluación de Calidad de Procesamiento de Muestra";

    protected override async System.Threading.Tasks.Task<AssessmentQualityCheckDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AssessmentQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AssessmentQualityCheckInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            AssessmentId = ConcreteBindingContext.Assessment.Id,
            AuthorId = ConcreteBindingContext.Author.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<AssessmentQualityCheckDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AssessmentQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AssessmentQualityCheckInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            AssessmentId = ConcreteBindingContext.Assessment.Id,
            AuthorId = ConcreteBindingContext.Author.Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnApply(sender, args);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnCancel(sender, args);
    }

    private void AssessmentPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.AssessmentPickPage(AssessmentPicked_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void AuthorPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void AssessmentPicked_Callback(AssessmentDisplayModel model)
    {
        ConcreteBindingContext.Assessment = model;

        hasChangesFlag = true;
    }
}