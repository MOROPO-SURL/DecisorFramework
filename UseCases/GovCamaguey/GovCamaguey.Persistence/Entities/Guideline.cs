namespace MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities
{
    public class Guideline : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public int Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
