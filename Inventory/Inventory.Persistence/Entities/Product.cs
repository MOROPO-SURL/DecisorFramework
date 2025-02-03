using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class Product : Core.Persistence.Entities.Contract.AbstractGoods
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultUnitMeasurementId))]
        public UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid DefaultUnitMeasurementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FamilyId))]
        public Family Family { get; set; }
        public int? FamilyId { get; set; }

        public System.TimeSpan? ExpirationTime { get; set; }

        public virtual ICollection<Classification> Classifications { get; set; }

        public List<ProductCustomAttributeBridge> CustomAttributeBridges { get; set; } = new List<ProductCustomAttributeBridge>();

        public List<ProductWarehousingDecreaseKindBridge> WarehousingDecreaseKindBridges { get; set; } = new List<ProductWarehousingDecreaseKindBridge>();
    }
}

