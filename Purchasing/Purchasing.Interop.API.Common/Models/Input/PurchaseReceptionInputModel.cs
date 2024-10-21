using System.Collections.Generic;
using System.Linq;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseReceptionInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PurchaseReception, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid PurchaseId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid WarehouseId { get; set; }

        public string Description { get; set; }

        public List<PurchaseReceptionProductWeightBridgeModel> WeightBridges { get; set; } = new List<PurchaseReceptionProductWeightBridgeModel>();

        public PurchaseReception Export()
        {
            var entity = new PurchaseReception { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(PurchaseReception entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(PurchaseReception entity)
        {
            entity.Description = Description;

            if (entity.PurchaseId != PurchaseId)
            {
                entity.Purchase = null;
                entity.PurchaseId = PurchaseId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }

            entity.ProductWeightBridges = WeightBridges.Select(model => new PurchaseReceptionProductWeightBridge
            {
                ProwId = entity.Id,
                SternId = model.Product.Id,
                Amount = model.Amount,
                Decrease = model.Decrease,
                CostCenterId = model.CostCenter.Id
            }).ToList();
        }
    }
}
