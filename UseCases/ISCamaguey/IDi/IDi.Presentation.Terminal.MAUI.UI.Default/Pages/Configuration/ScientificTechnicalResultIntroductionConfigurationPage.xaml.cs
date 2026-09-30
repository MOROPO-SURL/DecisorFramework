using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ScientificTechnicalResultIntroductionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ScientificTechnicalResultIntroductionDisplayModel, ScientificTechnicalResultIntroductionDisplayModel, Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel>
{
    public ScientificTechnicalResultIntroductionConfigurationPage(System.Action<ScientificTechnicalResultIntroductionDisplayModel> successAction, Models.Page.Configuration.ScientificTechnicalResultIntroductionConfigurationPageModel model, Validators.ScientificTechnicalResultIntroductionConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Introducción de Resultados";

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultIntroductionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultIntroductionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultIntroductionInputModel
        {
            Id = System.Guid.NewGuid(),
            Scenery = ConcreteBindingContext.Scenary,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ResultId = ConcreteBindingContext.Result.Id,
            Supervisors = [.. ConcreteBindingContext.Supervisors]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultIntroductionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultIntroductionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultIntroductionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Scenery = ConcreteBindingContext.Scenary,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ResultId = ConcreteBindingContext.Result.Id,
            Supervisors = [.. ConcreteBindingContext.Supervisors]
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

    private void ResultPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ScientificTechnicalResultPickPage(ResultPickComplete_Callback)));
    }

    private void SupervisorAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(EmployeePickComplete_Callback)));
    }

    private void SupervisorDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
    }

    private void SupervisorRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta elemento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as EmployeeDisplayModel;

                ConcreteBindingContext.Supervisors.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ResultPickComplete_Callback(ScientificTechnicalResultDisplayModel model)
    {
        ConcreteBindingContext.Result = model;
    }

    private void EmployeePickComplete_Callback(EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Supervisors.Add(model);

        hasChangesFlag = true;
    }
}