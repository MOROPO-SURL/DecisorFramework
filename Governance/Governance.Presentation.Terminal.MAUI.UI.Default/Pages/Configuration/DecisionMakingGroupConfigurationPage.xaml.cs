using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DecisionMakingGroupConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
{
    public DecisionMakingGroupConfigurationPage(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> successAction, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.AdministrativeEntity != null)
        {
            for (int i = 0; i < model.AvailableAdministrativeEntities.Length; i++)
            {
                var current = model.AvailableAdministrativeEntities[i];

                if (model.AdministrativeEntity.Id != current.Id) continue;

                AdministrativeEntityPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Grupo Decisor";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.DecisionMakingGroupInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            LeaderId = ConcreteBindingContext.Leader.Id,
            Members = [.. ConcreteBindingContext.Members],
            Collaborators = [.. ConcreteBindingContext.Collaborators],
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.DecisionMakingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.DecisionMakingGroupInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            StructureId = ConcreteBindingContext.AdministrativeEntity.Id,
            LeaderId = ConcreteBindingContext.Leader.Id,
            Members = [.. ConcreteBindingContext.Members],
            Collaborators = [.. ConcreteBindingContext.Collaborators],
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void LeaderPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(LeaderPickComplete_Callback)));
    }

    private void MemberAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(MemberPickComplete_Callback)));
    }

    private void CollaboratorAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(CollaboratorPickComplete_Callback)));
    }

    private void MemberDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
    }

    private void CollaboratorDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.PersonContactDetailPage(target, null));
    }

    private void MemberRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta miembro?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

                ConcreteBindingContext.Members.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void CollaboratorRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta colaborador?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

                ConcreteBindingContext.Collaborators.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void LeaderPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Leader = model;
    }

    private void MemberPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Members.Add(model);
    }

    private void CollaboratorPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Collaborators.Add(model);
    }
}