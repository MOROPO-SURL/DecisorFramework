namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class Product : Core.Persistence.Entities.Contract.AbstractGoods
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultUnitMeasurementId))]
        public Domain.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid DefaultUnitMeasurementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FamilyId))]
        public Family Family { get; set; }
        public int? FamilyId { get; set; }

        public System.TimeSpan? ExpirationTime { get; set; }

        public virtual System.Collections.Generic.ICollection<Classification> Classifications { get; set; }

        public System.Collections.Generic.List<ProductCustomAttributeBridge> CustomAttributeBridges { get; set; } = new System.Collections.Generic.List<ProductCustomAttributeBridge>();

        public System.Collections.Generic.List<ProductWarehousingDecreaseKindBridge> WarehousingDecreaseKindBridges { get; set; } = new System.Collections.Generic.List<ProductWarehousingDecreaseKindBridge>();
    }
}

