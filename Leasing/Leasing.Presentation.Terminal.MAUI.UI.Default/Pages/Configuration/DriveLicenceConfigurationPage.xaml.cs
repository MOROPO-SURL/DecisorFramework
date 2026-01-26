using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DriveLicenceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DriveLicenceDisplayModel, Interop.API.Common.Models.Display.DriveLicenceDisplayModel, Models.Page.Configuration.DriveLicenceConfigurationPageModel>
{
    public DriveLicenceConfigurationPage(System.Action<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> successAction, Models.Page.Configuration.DriveLicenceConfigurationPageModel model) : base(successAction, model, new Validators.DriveLicenceConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Licencia de Conducción";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.DriveLicenceDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Contact = ConcreteBindingContext.Contact,
            Code = ConcreteBindingContext.Code,
            Reference = ConcreteBindingContext.Reference,
            ReleasedAt = new System.DateTime(ConcreteBindingContext.ReleasedAtYear, 1, 1),
            ExpireAt = new System.DateTime(ConcreteBindingContext.ExpireAtYear, ConcreteBindingContext.ExpireAtMonth, 1),
            VehicleKindBridges = [.. ConcreteBindingContext.VehicleKindBridges]
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.DriveLicenceDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Contact = ConcreteBindingContext.Contact,
            Code = ConcreteBindingContext.Code,
            Reference = ConcreteBindingContext.Reference,
            ReleasedAt = new System.DateTime(ConcreteBindingContext.ReleasedAtYear, 1, 1),
            ExpireAt = new System.DateTime(ConcreteBindingContext.ExpireAtYear, ConcreteBindingContext.ExpireAtMonth, 1),
            VehicleKindBridges = [.. ConcreteBindingContext.VehicleKindBridges]
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void VehicleKindBridgeCreationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = new Models.Page.Configuration.DriveLicenceVehicleKindBridgeConfigurationPageModel(null);

        var apiConnectClient = new Domain.Interop.API.Connect.Clients.VehicleKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;

        apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    HandleException(task.Exception);
                }
                else
                {
                    model.AvailableVehicleKinds = task.Result;

                    this.NavigationPushPageAsync(new DriveLicenceVehicleKindBridgeConfigurationPage(VehicleKindBridgeCreationComplete_Callback, model));
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void VehicleKindBridgeEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel;

        var model = new Models.Page.Configuration.DriveLicenceVehicleKindBridgeConfigurationPageModel(target);

        var apiConnectClient = new Domain.Interop.API.Connect.Clients.VehicleKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;

        apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                if (task.Exception != null || task.IsCanceled)
                {
                    HandleException(task.Exception);
                }
                else
                {
                    model.AvailableVehicleKinds = task.Result;

                    this.NavigationPushPageAsync(new DriveLicenceVehicleKindBridgeConfigurationPage(VehicleKindBridgeEditionComplete_Callback, model));
                }

                ConcreteBindingContext.IsBusy = false;
            });
        });
    }

    private void VehicleKindBridgeRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta categoría?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel;

                ConcreteBindingContext.VehicleKindBridges.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void VehicleKindBridgeCreationComplete_Callback(Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel model)
    {
        if (ConcreteBindingContext.VehicleKindBridges.Any(item => item.Category == model.Category))
        {
            DisplayAlert("Aviso", "Ya se ha definido esta categoría.", "Aceptar");

            return;
        }

        ConcreteBindingContext.VehicleKindBridges.Add(model);
    }

    private void VehicleKindBridgeEditionComplete_Callback(Interop.API.Common.Models.Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel model)
    {
        ConcreteBindingContext.VehicleKindBridges[ConcreteBindingContext.VehicleKindBridges.IndexOf(model)] = model;
    }
}