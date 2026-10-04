using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AwardResultConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<AwardResultDisplayModel, AwardResultDisplayModel, Models.Page.Configuration.AwardResultConfigurationPageModel>
{
    public AwardResultConfigurationPage(System.Action<AwardResultDisplayModel> successAction, Models.Page.Configuration.AwardResultConfigurationPageModel model, Validators.AwardResultConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Logro Científico";

    protected override async System.Threading.Tasks.Task<AwardResultDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AwardResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AwardResultInputModel
        {
            Id = System.Guid.NewGuid(),
            Title = ConcreteBindingContext.Title,
            AwardModality = ConcreteBindingContext.AwardModality,
            AwardKindId = ConcreteBindingContext.AwardKind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            ReceptorId = ConcreteBindingContext.Receptor.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<AwardResultDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AwardResultsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AwardResultInputModel
        {
            Id = ConcreteBindingContext.Id,
            Title = ConcreteBindingContext.Title,
            AwardModality = ConcreteBindingContext.AwardModality,
            AwardKindId = ConcreteBindingContext.AwardKind.Id,
            Description = ConcreteBindingContext.Description,
            At = ConcreteBindingContext.At,
            ProjectId = ConcreteBindingContext.Project?.Id,
            ReceptorId = ConcreteBindingContext.Receptor.Id,
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

    private void ReceptorPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(ReceptorPickComplete_Callback)));
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

    private void ReceptorPickComplete_Callback(EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Receptor = model;

        hasChangesFlag = true;
    }
}