using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Supervision.Interop.API.Common.Models;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Supervision.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/supervision/inventory")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class InventoryController : Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly IEntityRepository<Batch, System.Guid> batchRepository;
        private readonly IEntityRepository<Product, System.Guid> productRepository;
        private readonly IEntityRepository<Purchase, System.Guid> purchaseRepository;

        public InventoryController(IEntityRepository<Purchase, System.Guid> purchaseRepository, IEntityRepository<Product, System.Guid> productRepository, IEntityRepository<Batch, System.Guid> batchRepository, Microsoft.Extensions.Localization.IStringLocalizer<InventoryController> localizer, ILogger<InventoryController> logger) : base(localizer, logger)
        {
            this.batchRepository = batchRepository;
            this.productRepository = productRepository;
            this.purchaseRepository = purchaseRepository;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("overviews")]
        public virtual Microsoft.AspNetCore.Mvc.ActionResult<InventoryStockOverviewModel[]> GetOverviews()
        {
            var universe = batchRepository.FindBy(entity => entity.Amount > 0).ToArray().GroupBy(entity => entity.ProductId);

            var models = new List<InventoryStockOverviewModel>();

            foreach (var group in universe)
            {
                var model = new InventoryStockOverviewModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel()
                };

                model.Product.Import(productRepository.Get(group.Key));

                foreach (var item in group)
                {
                    model.Totalization += item.Amount;
                }

                models.Add(model);
            }

            return Ok(models);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("details/{key}")]
        public Microsoft.AspNetCore.Mvc.ActionResult<InventoryStockDetailsModel> GetDetails(System.Guid key)
        {
            var universe = batchRepository.FindBy(entity => entity.Amount > 0 && entity.ProductId == key)
                .Include(entity => entity.Reception)
                .ToArray();

            var groups = universe.GroupBy(entity => entity.WarehousingArea.Warehouse);

            var model = new InventoryStockDetailsModel
            {
                Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                Existences = new List<WarehouseExistenseModel>()
            };

            model.Product.Import(productRepository.Get(key));

            var costIterationCount = 0;

            // TODO Include Weights in cost calculations !!!
            // TODO Migrate unitary cost calculation from linear promodey to base on Amount promedy !!
            foreach (var group in groups)
            {
                var warehouseTotalization = decimal.Zero;

                foreach (var item in group)
                {
                    warehouseTotalization += item.Amount;

                    if (item.Reception is PurchaseReception)
                    {
                        var purchaseReception = (PurchaseReception)item.Reception;

                        var purchase = purchaseRepository.Get(purchaseReception.PurchaseId.Value);

                        var itemCost = decimal.Zero;

                        foreach (var _item in purchase.LegalProviderProductBridges)
                        {
                            if (_item.ProductId != key) continue;

                            costIterationCount++;

                            itemCost += _item.Cost;
                        }

                        foreach (var _item in purchase.NaturalProviderProductBridges)
                        {
                            if (_item.ProductId != key) continue;

                            costIterationCount++;

                            itemCost += _item.Cost;
                        }

                        model.WeightedCost += itemCost;
                    }
                    //else if (item.Reception is ProductionReception)
                    //{
                    // TODO Implment spected behavior!!
                    //}
                }

                var _model = new Inventory.Interop.API.Common.Models.Display.WarehouseDisplayModel();

                _model.Import(group.Key);

                model.Existences.Add(new WarehouseExistenseModel { Warehouse = _model, Amount = warehouseTotalization });

                model.Totalization += warehouseTotalization;
            }

            model.WeightedCost /= costIterationCount;

            return Ok(model);
        }
    }
}
