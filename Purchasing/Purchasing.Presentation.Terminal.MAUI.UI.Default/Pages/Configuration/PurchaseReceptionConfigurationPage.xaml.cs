using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class PurchaseReceptionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<Interop.API.Common.Models.Display.PurchaseReceptionDisplayModel>
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
            Description = concreteBindingContext.Description
        };

        foreach (var item in concreteBindingContext.Weights)
        {
            foreach (var _item in item.ProductWeights)
            {
                model.WeightBridges.Add(new Interop.API.Common.Models.Bridge.PurchaseReceptionProductWeightBridgeModel
                {
                    Product = _item.Product,
                    Amount = _item.Amount,
                    CostCenter = item.CostCenter,
                    // TODO Set Decrease
                    Batches = _item.Batchs.Select(__item => new Inventory.Interop.API.Common.Models.Input.BatchInputModel
                    {
                        ExternalReference = __item.ExternalReference,
                        Amount = __item.Amount,
                        WarehouseId = __item.Warehouse.Id,
                        ClassificationId = __item.Classification?.Id
                    }).ToList()
                });
            }
        }

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

        Dispatcher.Dispatch(() =>
        {
            concreteBindingContext.Purchase = model;

            hasChangesFlag = true;

            if (!resetWeights) return;

            ResetWeights();
        });
    }

    private void ResetWeights()
    {
        var concreteBindingContext = (Models.Page.Configuration.PurchaseReceptionConfigurationPageModel)BindingContext;

        concreteBindingContext.Weights.Clear();

        var costCenters = new List<Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel>();

        foreach (var item in concreteBindingContext.Purchase.LegalProviderProductBridges)
        {
            if (costCenters.Any(_item => _item.Id == item.CostCenter.Id)) continue;

            costCenters.Add(item.CostCenter);
        }

        foreach (var item in concreteBindingContext.Purchase.NaturalProviderProductBridges)
        {
            if (costCenters.Any(_item => _item.Id == item.CostCenter.Id)) continue;

            costCenters.Add(item.CostCenter);
        }

        costCenters = costCenters.OrderBy(model => model.Priority).ToList();

        foreach (var costCenter in costCenters)
        {
            var models = new List<Models.View.PurchaseReceptionProductWeightBridgeViewModel>();

            var products = new List<Inventory.Interop.API.Common.Models.Display.ProductDisplayModel>();

            foreach (var item in concreteBindingContext.Purchase.LegalProviderProductBridges)
            {
                if (item.CostCenter.Id != costCenter.Id || products.Any(_item => _item.Id == item.Product.Id)) continue;

                products.Add(item.Product);
            }

            foreach (var item in concreteBindingContext.Purchase.NaturalProviderProductBridges)
            {
                if (item.CostCenter.Id != costCenter.Id || products.Any(_item => _item.Id == item.Product.Id)) continue;

                products.Add(item.Product);
            }

            foreach (var product in products)
            {
                var amount = decimal.Zero;

                foreach (var bridge in concreteBindingContext.Purchase.LegalProviderProductBridges)
                {
                    if (bridge.CostCenter.Id != costCenter.Id || product.Id != bridge.Product.Id) continue;

                    amount += bridge.Amount;
                }

                foreach (var bridge in concreteBindingContext.Purchase.NaturalProviderProductBridges)
                {
                    if (bridge.CostCenter.Id != costCenter.Id || product.Id != bridge.Product.Id) continue;

                    amount += bridge.Amount;
                }

                var _model = new Models.View.PurchaseReceptionProductWeightBridgeViewModel
                {
                    Amount = amount,
                    Product = product
                };

                _model.Batchs.Add(new Models.View.BatchSpecificationViewModel
                {
                    ExternalReference = System.Guid.NewGuid().ToString().Substring(0, 6),
                    Amount = amount
                });

                models.Add(_model);
            }

            concreteBindingContext.Weights.Add(new Models.View.PurchaseReceptionWeightsByCostCenterViewModel { CostCenter = costCenter, ProductWeights = models.ToArray() });
        }
    }
}