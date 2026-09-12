using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AnalysisQualityCheckConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<AnalysisQualityCheckDisplayModel, AnalysisQualityCheckDisplayModel, Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel>
{
	public AnalysisQualityCheckConfigurationPage(System.Action<AnalysisQualityCheckDisplayModel> successAction, Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.AnalysisQualityCheckConfigurationPageModel> validator) : base(successAction, model, validator)
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Evaluación de Calidad de Análisis de Muestra";

    protected override async System.Threading.Tasks.Task<AnalysisQualityCheckDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AnalysisQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AnalysisQualityCheckInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            AnalysisId = ConcreteBindingContext.Analysis.Id,
            AuthorId = ConcreteBindingContext.Author.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<AnalysisQualityCheckDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AnalysisQualityChecksAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AnalysisQualityCheckInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            QualityPercent = ConcreteBindingContext.QualityPercent,
            Description = ConcreteBindingContext.Description,
            AnalysisId = ConcreteBindingContext.Analysis.Id,
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

    private void AnalysisPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.AnalysisPickPage(AnalysisPicked_Callback)));
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

    private void AnalysisPicked_Callback(AnalysisDisplayModel model)
    {
        ConcreteBindingContext.Analysis = model;

        hasChangesFlag = true;
    }
}