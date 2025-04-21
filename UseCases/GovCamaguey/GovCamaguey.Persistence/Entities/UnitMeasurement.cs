namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class UnitMeasurement : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
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
    }
}

