using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class BankBranchConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.BankBranchDisplayModel, Interop.API.Common.Models.Display.BankBranchDisplayModel, Models.Page.Configuration.BankBranchConfigurationPageModel>
{
    public BankBranchConfigurationPage(System.Action<Interop.API.Common.Models.Display.BankBranchDisplayModel> successAction, Models.Page.Configuration.BankBranchConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.BankBranchConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Agency != null)
        {
            for (int i = 0; i < model.AvailableAgencies.Length; i++)
            {
                var current = model.AvailableAgencies[i];

                if (model.Agency.Id != current.Id) continue;

                AgencyPicker.SelectedIndex = i;
                AgencyPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Sucursal Bancaria";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankBranchDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankBranchesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.BankBranchInputModel
        {
            Id = System.Guid.NewGuid(),
            Number = ConcreteBindingContext.Number,
            Priority = ConcreteBindingContext.Priority,
            AgencyId = ConcreteBindingContext.AvailableAgencies[AgencyPicker.SelectedIndex].Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.BankBranchDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.BankBranchesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.BankBranchInputModel
        {
            Id = ConcreteBindingContext.Id,
            Number = ConcreteBindingContext.Number,
            Priority = ConcreteBindingContext.Priority,
            AgencyId = ConcreteBindingContext.AvailableAgencies[AgencyPicker.SelectedIndex].Id,
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