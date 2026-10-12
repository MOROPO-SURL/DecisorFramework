using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientVehicleLeasingControlActionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<NaturalClientVehicleLeasingControlActionDisplayModel, NaturalClientVehicleLeasingControlActionDisplayModel, Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel>
{
    public NaturalClientVehicleLeasingControlActionConfigurationPage(System.Action<NaturalClientVehicleLeasingControlActionDisplayModel> successAction, Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.NaturalClientVehicleLeasingControlActionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Acción de Control de Arrendamiento de Vehículo a Cliente Natural";

    protected override async System.Threading.Tasks.Task<NaturalClientVehicleLeasingControlActionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingControlActionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientVehicleLeasingControlActionInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            SupervisionGroupId = ConcreteBindingContext.SupervisionGroup.Id,
            Description = ConcreteBindingContext.Description,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<NaturalClientVehicleLeasingControlActionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingControlActionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientVehicleLeasingControlActionInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            SupervisionGroupId = ConcreteBindingContext.SupervisionGroup.Id,
            Description = ConcreteBindingContext.Description,
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

    private void LeasingPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.NaturalClientVehicleLeasingPickPage(LeasingPickComplete_Callback)));
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

    private void LeasingPickComplete_Callback(NaturalClientVehicleLeasingDisplayModel model)
    {
        ConcreteBindingContext.Leasing = model;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}