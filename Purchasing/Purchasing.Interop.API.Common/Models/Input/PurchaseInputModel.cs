using System.Collections.Generic;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Purchase, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid? PlanId { get; set; }

        public System.Guid? ZoneId { get; set; }

        public System.Guid PurchaserId { get; set; }

        public string Description { get; set; }

        public List<PurchaseProductLegalProviderBridgeModel> LegalProviderProductBridges { get; set; } = new List<PurchaseProductLegalProviderBridgeModel>();

        public List<PurchaseProductNaturalProviderBridgeModel> NaturalProviderProductBridges { get; set; } = new List<PurchaseProductNaturalProviderBridgeModel>();

        public List<PurchasePurchaseSpentBridgeModel> SpentBridges { get; set; } = new List<PurchasePurchaseSpentBridgeModel>();

        public List<PurchaseEmployeeBridgeModel> EmployeeBridges { get; set; } = new List<PurchaseEmployeeBridgeModel>();

        public List<PurchaseColaboratorBridgeModel> ColaboratorBridges { get; set; } = new List<PurchaseColaboratorBridgeModel>();

        public Purchase Export()
        {
            var entity = new Purchase { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Purchase entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Purchase entity)
        {
            entity.Description = Description;

            if (entity.ZoneId != ZoneId)
            {
                entity.Zone = null;
                entity.ZoneId = ZoneId;
            }

            if (entity.PurchaserId != PurchaserId)
            {
                entity.Purchaser = null;
                entity.PurchaserId = PurchaserId;
            }

            if (entity.PlanId != PlanId)
            {
                entity.Plan = null;
                entity.PlanId = PlanId;
            }

            // TODO Implement auto-approved behavior
        }
    }
}
