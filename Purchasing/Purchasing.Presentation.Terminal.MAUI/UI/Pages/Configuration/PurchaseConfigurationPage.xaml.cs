using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Pages.Configuration;

public partial class PurchaseConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseDisplayModel>
{
    public PurchaseConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseDisplayModel> successAction, Models.Page.Configuration.PurchaseConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Zone != null)
        {
            for (int i = 0; i < model.AvailableZones.Length; i++)
            {
                var current = model.AvailableZones[i];

                if (model.Zone.Id != current.Id) continue;

                ZonePicker.SelectedIndex = i;
                ZonePicker.SelectedItem = current;

                break;
            }
        }

        if (model.Purchaser != null)
        {
            for (int i = 0; i < model.AvailablePurchasers.Length; i++)
            {
                var current = model.AvailablePurchasers[i];

                if (model.Purchaser.Id != current.Id) continue;

                PurchaserPicker.SelectedIndex = i;
                PurchaserPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchasesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseInputModel
        {
            Id = System.Guid.NewGuid(),
            PlanId = concreteBindingContext.Plan?.Id ?? null,
            ZoneId = ZonePicker.SelectedIndex == -1 ? null : concreteBindingContext.AvailableZones[PurchaserPicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            PurchaserId = concreteBindingContext.AvailablePurchasers[PurchaserPicker.SelectedIndex].Id,
            LegalProviderProductBridges = concreteBindingContext.LegalProviderProductBridges.ToList(),
            NaturalProviderProductBridges = concreteBindingContext.NaturalProviderProductBridges.ToList(),
            SpentBridges = concreteBindingContext.SpentBridges.ToList(),
            EmployeeBridges = concreteBindingContext.EmployeeBridges.ToList(),
            ColaboratorBridges = concreteBindingContext.ColaboratorBridges.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseDisplayModel> PerformEditionAsync()
    {
        throw new System.InvalidOperationException();
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void PlanPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PurchasePlanToCompletePickPage(PlanPickComplete_Callback)));
    }

    private void PlanPickComplete_Callback(Interop.API.Common.Models.Display.PurchasePlanDisplayModel model)
    {
        ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).Plan = model;

        ZonePicker.SelectedIndex = -1;
        ZonePicker.IsEnabled = false;
    }

    private void AddLegalProviderPurchaseButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel(null)
                {
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new LegalProviderPurchaseProductBridgeConfigurationPage(PurchaseLegalProviderProductBridgeCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void AddNaturalProviderPurchaseButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel(null)
                {
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new NaturalProviderPurchaseProductBridgeConfigurationPage(PurchaseNaturalProviderProductBridgeCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void AddSpentButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        //System.Threading.Tasks.Task.Run(async () =>
        //{
        //    try
        //    {
        //        var spentsAPIConnectClient = new Web.API.Connect.Clients.PurchaseSpentsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        //        var model = new Models.Page.PurchaseSpentBridgeConfigurationPageModel(null)
        //        {
        //            AvailableSpents = await spentsAPIConnectClient.GetAsync()
        //        };

        //        Dispatcher.Dispatch(() =>
        //        {
        //            concreteBindingContext.IsBusy = false;

        //            this.NavigationPushPageAsync(new PurchaseSpentBridgeConfigurationPage(PurchaseSpentBridgeCreateSuccess_Callback, model));
        //        });
        //    }
        //    catch (System.Exception exception)
        //    {
        //        Dispatcher.Dispatch(() =>
        //        {
        //            // TODO Handle exception
        //        });
        //    }
        //});
    }

    private void EditLegalProviderPurchaseButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel;

                var model = new Models.Page.Configuration.LegalProviderPurchaseProductBridgeConfigurationPageModel()
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id),
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new LegalProviderPurchaseProductBridgeConfigurationPage(PurchaseLegalProviderProductBridgeEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void EditNaturalProviderPurchaseButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        concreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var unitMeasurementsAPIConnectClient = new Essential.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());
                var costCentersAPIConnectClient = new Financial.Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel;

                var model = new Models.Page.Configuration.NaturalProviderPurchaseProductBridgeConfigurationPageModel(target)
                {
                    AvailableUnitMeasurements = await unitMeasurementsAPIConnectClient.GetReleatedsAsync(target.Product.DefaultUnitMeasurement.Id),
                    AvailableCostCenters = await costCentersAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch((System.Action)(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new NaturalProviderPurchaseProductBridgeConfigurationPage(PurchaseNaturalProviderProductBridgeEditSuccess_Callback, model));
                }));
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    // TODO Handle exception
                });
            }
        });
    }

    private void PurchaseLegalProviderProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta compra a proveedor legal?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).LegalProviderProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel));
        });
    }

    private void PurchaseNaturalProviderProductBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta compra a proveedor natural?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).NaturalProviderProductBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel));
        });
    }

    private void PurchaseSpentBridgeRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta gasto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).SpentBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.PurchasePurchaseSpentBridgeModel));
        });
    }

    private void PurchaseLegalProviderProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel model)
    {
        ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).LegalProviderProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void PurchaseNaturalProviderProductBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel model)
    {
        ((Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext).NaturalProviderProductBridges.Add(model);

        hasChangesFlag = true;
    }

    private void PurchaseLegalProviderProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseProductLegalProviderBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.LegalProviderProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = concreteBindingContext.LegalProviderProductBridges.IndexOf(reference);

        concreteBindingContext.LegalProviderProductBridges[index] = model;

        hasChangesFlag = true;
    }

    private void PurchaseNaturalProviderProductBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.PurchaseProductNaturalProviderBridgeModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.NaturalProviderProductBridges.First(item => item.Product.Id == model.Product.Id);

        var index = concreteBindingContext.NaturalProviderProductBridges.IndexOf(reference);

        concreteBindingContext.NaturalProviderProductBridges[index] = model;

        hasChangesFlag = true;
    }
}