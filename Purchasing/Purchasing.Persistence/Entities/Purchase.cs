using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class Purchase : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PlanId))]
        public PurchasePlan Plan { get; set; }
        public System.Guid? PlanId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ZoneId))]
        public PurchaseZone Zone { get; set; }
        public System.Guid? ZoneId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PurchaserId))]
        public Essential.Persistence.Entities.Employee Purchaser { get; set; }
        public System.Guid PurchaserId { get; set; }

        public string Description { get; set; }

        public PurchaseReception Reception { get; set; }

        public List<PurchaseProductLegalProviderBridge> LegalProviderProductBridges { get; set; } = new List<PurchaseProductLegalProviderBridge>();

        public List<PurchaseProductNaturalProviderBridge> NaturalProviderProductBridges { get; set; } = new List<PurchaseProductNaturalProviderBridge>();

        public List<PurchasePurchaseSpentBridge> SpentBridges { get; set; } = new List<PurchasePurchaseSpentBridge>();

        public List<PurchaseEmployeeBridge> EmployeeBridges { get; set; } = new List<PurchaseEmployeeBridge>();

        public List<PurchaseColaboratorBridge> ColaboratorBridges { get; set; } = new List<PurchaseColaboratorBridge>();
    }
}
