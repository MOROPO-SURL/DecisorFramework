using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class MeetingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.MeetingDisplayModel, Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel>
{
    public MeetingConfigurationPage(System.Action<Interop.API.Common.Models.Display.MeetingDisplayModel> successAction, Models.Page.Configuration.MeetingConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Group != null)
        {
            for (int i = 0; i < model.AvailableGroups.Length; i++)
            {
                var current = model.AvailableGroups[i];

                if (model.Group.Id != current.Id) continue;

                GroupPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Reunión";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.MeetingDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.MeetingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.MeetingInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.AtDate.Date + ConcreteBindingContext.AtTime,
            Summary = ConcreteBindingContext.Summary,
            Rapporteurship = ConcreteBindingContext.Rapporteurship,
            DecisionMakingGroupId = ConcreteBindingContext.AvailableGroups[GroupPicker.SelectedIndex].Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            InternalInvitations = ConcreteBindingContext.InternalInvitations.ToList(),
            ExternalInvitations = ConcreteBindingContext.ExternalInvitations.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.MeetingDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.MeetingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.MeetingInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            At = ConcreteBindingContext.AtDate.Date + ConcreteBindingContext.AtTime,
            Summary = ConcreteBindingContext.Summary,
            Rapporteurship = ConcreteBindingContext.Rapporteurship,
            DecisionMakingGroupId = ConcreteBindingContext.AvailableGroups[GroupPicker.SelectedIndex].Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            InternalInvitations = ConcreteBindingContext.InternalInvitations.ToList(),
            ExternalInvitations = ConcreteBindingContext.ExternalInvitations.ToList()
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

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void InternalInvitationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(InternalInvitationPickComplete_Callback)));
    }

    private void ExternalInvitationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ExternalInvitationPickComplete_Callback)));
    }

    private void InternalInvitationDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
    }

    private void ExternalInvitationDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.PersonContactDetailPage(target, null));
    }

    private void InternalInvitationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta invitado interno?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel;

                ConcreteBindingContext.InternalInvitations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ExternalInvitationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta invitado externo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel;

                ConcreteBindingContext.ExternalInvitations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AuthorPickComplete_Callback(HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;
    }

    private void InternalInvitationPickComplete_Callback(HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.InternalInvitations.Add(model);
    }

    private void ExternalInvitationPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.ExternalInvitations.Add(model);
    }
}