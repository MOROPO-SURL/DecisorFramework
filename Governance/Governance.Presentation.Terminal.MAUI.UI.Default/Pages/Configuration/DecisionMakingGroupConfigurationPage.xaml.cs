using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DecisionMakingGroupConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel>
{
    public DecisionMakingGroupConfigurationPage(System.Action<Interop.API.Common.Models.Display.DecisionMakingGroupDisplayModel> successAction, Models.Page.Configuration.DecisionMakingGroupConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Structure != null)
        {
            for (int i = 0; i < model.AvailableStructures.Length; i++)
            {
                var current = model.AvailableStructures[i];

                if (model.Structure.Id != current.Id) continue;

                StructurePicker.SelectedIndex = i;

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
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            LeaderId = ConcreteBindingContext.Leader.Id,
            Members = ConcreteBindingContext.Members.ToList(),
            Collaborators = ConcreteBindingContext.Collaborators.ToList()
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
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id,
            LeaderId = ConcreteBindingContext.Leader.Id,
            Members = ConcreteBindingContext.Members.ToList(),
            Collaborators = ConcreteBindingContext.Collaborators.ToList()
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