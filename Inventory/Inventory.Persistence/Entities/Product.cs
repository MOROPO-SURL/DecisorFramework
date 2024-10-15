using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
	public class Product : Core.Persistence.Entities.Contract.AbstractGoods
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DefaultUnitMeasurementId))]
        public Essential.Persistence.Entities.UnitMeasurement UnitMeasurement { get; set; }
        public System.Guid DefaultUnitMeasurementId { get; set; }

        public List<ProductCustomAttributeBridge> CustomAttributeBridges { get; set; } = new List<ProductCustomAttributeBridge>();

        public List<ProductWarehousingDecreaseKindBridge> WarehousingDecreaseKindBridges { get; set; } = new List<ProductWarehousingDecreaseKindBridge>();
    }
}

