using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchasePlan : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public System.DateTime? ApprovedAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PlannerId))]
        public Essential.Persistence.Entities.Employee Planner { get; set; }
        public System.Guid PlannerId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Essential.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DecisorId))]
        public Essential.Persistence.Entities.Employee Decisor { get; set; }
        public System.Guid DecisorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ZoneId))]
        public PurchaseZone Zone { get; set; }
        public System.Guid ZoneId { get; set; }

        public Purchase Purchase { get; set; }

        public List<PurchasePlanOutputProductBridge> OutputProductBridges { get; set; } = new List<PurchasePlanOutputProductBridge>();

        public List<PurchasePlanInputProductBridge> InputProductBridges { get; set; } = new List<PurchasePlanInputProductBridge>();

        public List<PurchasePlanLegalProviderBridge> LegalProviderBridges { get; set; } = new List<PurchasePlanLegalProviderBridge>();

        public List<PurchasePlanNaturalProviderBridge> NaturalProviderBridges { get; set; } = new List<PurchasePlanNaturalProviderBridge>();
    }
}
