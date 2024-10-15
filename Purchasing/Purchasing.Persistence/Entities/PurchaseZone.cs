using System.Collections.Generic;
using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseZone : INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
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

        public List<LegalProviderPurchaseZoneBridge> LegalProviderBridges { get; set; } = new List<LegalProviderPurchaseZoneBridge>();

        public List<NaturalProviderPurchaseZoneBridge> NaturalProviderBridges { get; set; } = new List<NaturalProviderPurchaseZoneBridge>();

        public List<PurchaseZoneSpentBridge> SpentBridges { get; set; } = new List<PurchaseZoneSpentBridge>();
    }
}
