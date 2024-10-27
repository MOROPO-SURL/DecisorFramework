using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Pages.Configuration;

public partial class PurchaseReceptionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseReceptionDisplayModel>
{
    public PurchaseReceptionConfigurationPage(System.Action<Interop.API.Common.Models.Display.PurchaseReceptionDisplayModel> successAction, Models.Page.Configuration.PurchaseReceptionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Purchase == null) return;

        ResetWeights();
    }

    protected override string EntityTypeName => "Recepción de Compra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseReceptionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.PurchaseReceptionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.PurchaseReceptionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.PurchaseReceptionInputModel
        {
            Id = System.Guid.NewGuid(),
            PurchaseId = concreteBindingContext.Purchase.Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            WarehouseId = concreteBindingContext.AvailableWarehouses[WarehousePicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            WeightBridges = concreteBindingContext.RegularWeights.Select(item => new Interop.API.Common.Models.Bridge.PurchaseReceptionProductWeightBridgeModel
            {
                Product = item.Product,
                Amount = item.Amount
                // TODO Set Decrease
            }).ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.PurchaseReceptionDisplayModel> PerformEditionAsync()
    {
        throw new System.InvalidOperationException();
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void PurchasePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ForReceptionPurchasePickPage(PurchasePickComplete_Callback)));
    }

    private void PurchasePickComplete_Callback(Interop.API.Common.Models.Display.PurchaseDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseReceptionConfigurationPageModel)BindingContext;

        var resetWeights = concreteBindingContext.Purchase == null || concreteBindingContext.Purchase.Id != model.Id;

        concreteBindingContext.Purchase = model;

        hasChangesFlag = true;

        if (!resetWeights) return;

        ResetWeights();
    }

    private void ResetWeights()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseReceptionConfigurationPageModel)BindingContext;

        concreteBindingContext.RegularWeights.Clear();
        concreteBindingContext.ContextualWeights.Clear();

        var regularProducts = new List<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel>();

        foreach (var item in concreteBindingContext.Purchase.LegalProviderProductBridges)
        {
            if (regularProducts.Any(_item => _item.Id == item.Product.Id)) continue;

            regularProducts.Add(item.Product);
        }

        foreach (var item in concreteBindingContext.Purchase.NaturalProviderProductBridges) 
        {
            if (item.CostCenter != null) continue;

            if (regularProducts.Any(_item => _item.Id == item.Product.Id)) continue;

            regularProducts.Add(item.Product);
        }

        foreach (var item in regularProducts)
        {
            var amount = decimal.Zero;

            foreach (var _item in concreteBindingContext.Purchase.LegalProviderProductBridges)
            {
                if (item.Id != _item.Product.Id) continue;

                amount += _item.Amount;
            }

            foreach (var _item in concreteBindingContext.Purchase.NaturalProviderProductBridges)
            {
                if (_item.CostCenter == null) continue;

                if (item.Id != _item.Product.Id) continue;

                amount += _item.Amount;
            }

            concreteBindingContext.RegularWeights.Add(new Models.View.PurchaseReceptionProductCommonWeightBridgeViewModel
            {
                Amount = amount,
                Product = item
            });
        }

        var contextualProducts = new List<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel>();

        foreach (var item in concreteBindingContext.Purchase.NaturalProviderProductBridges)
        {
            if (item.CostCenter != null) continue;

            if (contextualProducts.Any(_item => _item.Id == item.Product.Id)) continue;

            contextualProducts.Add(item.Product);
        }

        foreach (var item in contextualProducts)
        {
            var amount = decimal.Zero;

            foreach (var _item in concreteBindingContext.Purchase.NaturalProviderProductBridges)
            {
                if (_item.CostCenter != null) continue;

                if (item.Id != _item.Product.Id) continue;

                amount += _item.Amount;
            }

            concreteBindingContext.ContextualWeights.Add(new Models.View.PurchaseReceptionProductCommonWeightBridgeViewModel
            {
                Amount = amount,
                Product = item
            });
        }
    }
}