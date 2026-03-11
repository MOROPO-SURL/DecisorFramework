namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkPosition : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Reference { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public WorkPositionKind Kind { get; set; }
        public System.Guid KindId { get; set; }

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get; set; }

        public string Description { get; set; }
    }
}
