namespace MOROPO.Framework.Decisor.Inventory.Persistence.Entities
{
    public class UnitMeasurement : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Symbol { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.Collections.Generic.List<UnitMeasurementConversionBridge> ConversionBridges { get; set; } = new System.Collections.Generic.List<UnitMeasurementConversionBridge>();
    }
}

