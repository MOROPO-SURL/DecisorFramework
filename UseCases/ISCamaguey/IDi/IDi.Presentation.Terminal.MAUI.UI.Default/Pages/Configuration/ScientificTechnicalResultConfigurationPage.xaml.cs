using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ScientificTechnicalResultConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ScientificTechnicalResultDisplayModel, ScientificTechnicalResultDisplayModel, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel>
{
    public ScientificTechnicalResultConfigurationPage(System.Action<ScientificTechnicalResultDisplayModel> successAction, Models.Page.Configuration.ScientificTechnicalResultConfigurationPageModel model, Validators.ScientificTechnicalResultConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Resultado CTI";

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.Kind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ScientificTechnicalResultDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ScientificTechnicalResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ScientificTechnicalResultInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            Reference = ConcreteBindingContext.Reference,
            KindId = ConcreteBindingContext.Kind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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

    private void ProjectPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProjectPickPage(ProjectPickComplete_Callback)));
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void ProjectPickComplete_Callback(ProjectDisplayModel model)
    {
        ConcreteBindingContext.Project = model;
    }
}