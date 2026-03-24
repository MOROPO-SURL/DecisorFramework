using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class MeetingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.MeetingDisplayModel, Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Input.AgreementInputModel> editionAgreements = [];
    private readonly List<Interop.API.Common.Models.Input.AgreementInputModel> incomingAgreements = [];
    private readonly List<Interop.API.Common.Models.Display.AgreementDisplayModel> outgoingAgreements = [];

    public MeetingConfigurationPage(System.Action<Interop.API.Common.Models.Display.MeetingDisplayModel> successAction, Models.Page.Configuration.MeetingConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.MeetingConfigurationPageModel> validator) : base(successAction, model, validator)
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
            DecisionMakingGroupId = ConcreteBindingContext.Group.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            InternalInvitations = [.. ConcreteBindingContext.InternalInvitations],
            ExternalInvitations = [.. ConcreteBindingContext.ExternalInvitations],
            IncomingAgreements = incomingAgreements,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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
            DecisionMakingGroupId = ConcreteBindingContext.Group.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            InternalInvitations = [.. ConcreteBindingContext.InternalInvitations],
            ExternalInvitations = [.. ConcreteBindingContext.ExternalInvitations],
            IncomingAgreements = incomingAgreements,
            EditionAgreements = editionAgreements,
            OutgoingAgreements = outgoingAgreements,
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

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(AuthorPickComplete_Callback)));
    }

    private void InternalInvitationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(InternalInvitationPickComplete_Callback)));
    }

    private void ExternalInvitationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ExternalInvitationPickComplete_Callback)));
    }

    private void InternalInvitationDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
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
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

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

    private void AgreementAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new AgreementConfigurationPage(AgreementCreateSuccess_Callback, new Models.Page.Configuration.AgreementConfigurationPageModel(null), new Validators.AgreementConfigurationValidator()));
    }

    private void AgreementEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new AgreementConfigurationPage(AgreementEditSuccess_Callback, new Models.Page.Configuration.AgreementConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.AgreementDisplayModel), new Validators.AgreementConfigurationValidator()));
    }

    private void AgreementRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este acuerdo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.AgreementDisplayModel;

                var handled = false;

                foreach (var item in incomingAgreements)
                {
                    if (item.Id != target.Id) continue;

                    incomingAgreements.Remove(incomingAgreements.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionAgreements)
                    {
                        if (item.Id != target.Id) continue;

                        editionAgreements.Remove(editionAgreements.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingAgreements.Add(target);
                }

                ConcreteBindingContext.Agreements.Remove(target);

                var index = 1;

                foreach (var item in ConcreteBindingContext.Agreements)
                {
                    item.Index = index++;
                }

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

    private void AgreementCreateSuccess_Callback(Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        model.Index = ConcreteBindingContext.Agreements.Count + 1;

        incomingAgreements.Add(new Interop.API.Common.Models.Input.AgreementInputModel
        {
            Id = model.Id,
            Index = model.Index,
            Title = model.Title,
            Description = model.Description,
            ResponsibleId = model.Responsible?.Id,
            EndAt = model.EndAt
        });

        ConcreteBindingContext.Agreements.Add(model);

        hasChangesFlag = true;
    }

    private void AgreementEditSuccess_Callback(Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingAgreements)
        {
            if (item.Id != model.Id) continue;

            item.Index = model.Index;
            item.Title = model.Title;
            item.Description = model.Description;
            item.ResponsibleId = model.Responsible?.Id;
            item.EndAt = model.EndAt;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionAgreements)
            {
                if (item.Id != model.Id) continue;

                item.Index = model.Index;
                item.Title = model.Title;
                item.Description = model.Description;
                item.ResponsibleId = model.Responsible?.Id;
                item.EndAt = model.EndAt;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionAgreements.Add(new Interop.API.Common.Models.Input.AgreementInputModel
            {
                Id = model.Id,
                Index = model.Index,
                Title = model.Title,
                Description = model.Description,
                ResponsibleId = model.Responsible?.Id,
                EndAt = model.EndAt
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Agreements)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Agreements[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void AuthorPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Author = model;
    }

    private void InternalInvitationPickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.InternalInvitations.Add(model);
    }

    private void ExternalInvitationPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.ExternalInvitations.Add(model);
    }
}