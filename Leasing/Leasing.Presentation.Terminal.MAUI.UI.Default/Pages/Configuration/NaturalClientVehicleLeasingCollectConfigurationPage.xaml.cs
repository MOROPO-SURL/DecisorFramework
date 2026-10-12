using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class NaturalClientVehicleLeasingCollectConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<NaturalClientVehicleLeasingCollectDisplayModel, NaturalClientVehicleLeasingCollectDisplayModel, Models.Page.Configuration.NaturalClientVehicleLeasingCollectConfigurationPageModel>
{
    public NaturalClientVehicleLeasingCollectConfigurationPage(System.Action<NaturalClientVehicleLeasingCollectDisplayModel> successAction, Models.Page.Configuration.NaturalClientVehicleLeasingCollectConfigurationPageModel model) : base(successAction, model, new Validators.NaturalClientVehicleLeasingCollectConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Cobro de Arrendamiento de Vehículo a Cliente Natural";

    protected override async System.Threading.Tasks.Task<NaturalClientVehicleLeasingCollectDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientVehicleLeasingCollectInputModel
        {
            Id = System.Guid.NewGuid(),
            ExpectedAt = ConcreteBindingContext.ExpectedAt,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            Amount = ConcreteBindingContext.Amount,
            Description = ConcreteBindingContext.Description,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<NaturalClientVehicleLeasingCollectDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.NaturalClientVehicleLeasingCollectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new NaturalClientVehicleLeasingCollectInputModel
        {
            Id = ConcreteBindingContext.Id,
            LeasingId = ConcreteBindingContext.Leasing.Id,
            Amount = ConcreteBindingContext.Amount,
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
}