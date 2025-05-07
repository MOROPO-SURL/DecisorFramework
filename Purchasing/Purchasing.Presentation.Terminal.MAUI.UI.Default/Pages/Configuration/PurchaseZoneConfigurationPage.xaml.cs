using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseZoneConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, Models.Page.Configuration.PurchaseZoneConfigurationPageModel>
{

    private readonly List<PurchaseZoneSpentBridgeModel> editionSpentBridges = [];
    private readonly List<PurchaseZoneSpentBridgeModel> incomingSpentBridges = [];
    private readonly List<PurchaseZoneSpentBridgeModel> outgoingSpentBridges = [];

    public PurchaseZoneConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> successAction, Models.Page.Configuration.PurchaseZoneConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Zona de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseZoneInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            IncomingSpentBridges = incomingSpentBridges
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseZonesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.PurchaseZoneInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            EditionSpentBridges = editionSpentBridges,
            IncomingSpentBridges = incomingSpentBridges,
            OutgoingSpentBridges = outgoingSpentBridges
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }
    
    private void AddSpentBridgeButton_Clicked(object sender, System.EventArgs eventArgs) 
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                var model = new Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel()
                {
                    AvailableCurrrencies = await currenciesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseZoneSpentBridgeConfigurationPage(SpentBridgeCreateSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void EditSpentBridgeButton_Clicked(object sender, System.EventArgs eventArgs) 
    {
        ConcreteBindingContext.IsBusy = true;

        System.Threading.Tasks.Task.Run(async () =>
        {
            try
            {
                var currenciesAPIConnectClient = new Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());
                
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PurchaseZoneSpentBridgeModel;

                var model = new Models.Page.Configuration.PurchaseZoneSpentBridgeConfigurationPageModel(target)
                {
                    AvailableCurrrencies = await currenciesAPIConnectClient.GetAsync()
                };

                Dispatcher.Dispatch(() =>
                {
                    ConcreteBindingContext.IsBusy = false;

                    this.NavigationPushPageAsync(new PurchaseZoneSpentBridgeConfigurationPage(SpentBridgeEditSuccess_Callback, model));
                });
            }
            catch (System.Exception exception)
            {
                Dispatcher.Dispatch(() =>
                {
                    Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(exception, this);
                });
            }
        });
    }

    private void SpentBridgeRemoveButton_Clicked(object sender, System.EventArgs eventArgs) 
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este gasto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as PurchaseZoneSpentBridgeModel;

                var handled = false;

                foreach (var item in incomingSpentBridges)
                {
                    if (item.Spent.Id != target.Spent.Id) continue;

                    incomingSpentBridges.Remove(editionSpentBridges.First(model => model.Spent.Id == target.Spent.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionSpentBridges)
                    {
                        if (item.Spent.Id != target.Spent.Id) continue;

                        editionSpentBridges.Remove(editionSpentBridges.First(model => model.Spent.Id == target.Spent.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingSpentBridges.Add(target);
                }

                ConcreteBindingContext.SpentBridges.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void SpentBridgeCreateSuccess_Callback(PurchaseZoneSpentBridgeModel model)
    {
        incomingSpentBridges.Add(model);

        ConcreteBindingContext.SpentBridges.Add(model);

        hasChangesFlag = true;
    }

    private void SpentBridgeEditSuccess_Callback(PurchaseZoneSpentBridgeModel model)
    {
        var handled = false;

        foreach (var item in incomingSpentBridges)
        {
            if (item.Spent.Id != model.Spent.Id) continue;

            item.Amount = model.Amount;
            item.Currency = model.Currency;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionSpentBridges)
            {
                if (item.Spent.Id != model.Spent.Id) continue;

                item.Amount = model.Amount;
                item.Currency = model.Currency;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionSpentBridges.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.SpentBridges)
        {
            index++;

            if (item.Spent.Id != model.Spent.Id) continue;

            ConcreteBindingContext.SpentBridges[index] = model;

            break;
        }

        hasChangesFlag = true;
    }
}