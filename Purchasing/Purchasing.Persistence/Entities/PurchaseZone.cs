using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseZone : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }

        public List<PurchaseZoneLegalProviderBridge> LegalProviderBridges { get; set; } = new List<PurchaseZoneLegalProviderBridge>();

        public List<PurchaseZoneNaturalProviderBridge> NaturalProviderBridges { get; set; } = new List<PurchaseZoneNaturalProviderBridge>();

        public List<PurchaseZoneSpentBridge> SpentBridges { get; set; } = new List<PurchaseZoneSpentBridge>();
    }
}
