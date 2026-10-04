using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class FamilyConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.FamilyDisplayModel, Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel>
{
    public FamilyConfigurationPage(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> successAction, Models.Page.Configuration.FamilyConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.FamilyConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Parent != null)
        {
            for (int i = 0; i < model.AvailableParents.Length; i++)
            {
                var current = model.AvailableParents[i];

                if (model.Parent.Id != current.Id) continue;

                ParentPicker.SelectedIndex = i;
                ParentPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Familia de Productos";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.FamilyDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Name = ConcreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        // TODO Try to recover added Category
        return null;
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.FamilyDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.FamiliesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.FamilyInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            ParentId = ParentPicker.SelectedIndex == -1 ? null : ConcreteBindingContext.AvailableParents[ParentPicker.SelectedIndex].Id,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
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
}
