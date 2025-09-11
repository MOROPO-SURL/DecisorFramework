namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class PropertySpace : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public Enumerations.PropertyAssignment? Assignment { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
        public System.Guid PropertyId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid? FeatureImageId { get; set; }

        public decimal Area { get; set; }

        public string Description { get; set; }
    }
}
