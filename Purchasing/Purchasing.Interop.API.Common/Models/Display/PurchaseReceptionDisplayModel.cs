using System.Linq;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseReceptionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseReception, System.Guid>
    {
        public System.Guid Id { get; set; }

        public PurchaseDisplayModel Purchase {  get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get; set; }

        public PurchaseReceptionProductWeightBridgeModel[] WeightBridges { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.PurchaseReception entity)
        {
            Id = entity.Id;
            Description = entity.Description;

            if (entity.Purchase != null)
            {
                Purchase = new PurchaseDisplayModel();

                Purchase.Import(entity.Purchase);
            }

            if (entity.Responsible != null) 
            {
                Responsible = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Responsible.Import(entity.Responsible);
            }

            WeightBridges = entity.ProductWeightBridges.Select(bridge =>
            {
                var model = new PurchaseReceptionProductWeightBridgeModel
                {
                    Amount = bridge.Amount,
                    Decrease = bridge.Decrease
                };

                if (bridge.Product != null)
                {
                    model.Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel();

                    model.Product.Import(bridge.Product);
                }

                if (bridge.CostCenter != null)
                {
                    model.CostCenter = new Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel();

                    model.CostCenter.Import(bridge.CostCenter);
                }

                return model;
            }).ToArray();
        }
    }
}
