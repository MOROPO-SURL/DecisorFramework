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
            AuthorId = ConcreteBindingContext.Author.Id,
            CubanStandards = [.. ConcreteBindingContext.CubanStandards],
            IsoStandards = [.. ConcreteBindingContext.IsoStandards]
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
            AuthorId = ConcreteBindingContext.Author.Id,
            CubanStandards = [.. ConcreteBindingContext.CubanStandards],
            IsoStandards = [.. ConcreteBindingContext.IsoStandards]
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

    private void CubanStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.CubanStandardPickPage(CubanStandardPickComplete_Callback)));
    }

    private void CubanStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.CubanStandardDetailPage(target, null));
    }

    private void CubanStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma cubana?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel;

                ConcreteBindingContext.CubanStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void IsoStandardAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.IsoStandardPickPage(IsoStandardPickComplete_Callback)));
    }

    private void IsoStandardDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

        this.NavigationPushModalPageAsync(new Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.IsoStandardDetailPage(target, null));
    }

    private void IsoStandardRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta norma ISO?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel;

                ConcreteBindingContext.IsoStandards.Remove(target);

                hasChangesFlag = true;
            });
        });
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

    private void CubanStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel model)
    {
        ConcreteBindingContext.CubanStandards.Add(model);

        hasChangesFlag = true;
    }

    private void IsoStandardPickComplete_Callback(Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel model)
    {
        ConcreteBindingContext.IsoStandards.Add(model);

        hasChangesFlag = true;
    }
}