namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectImpact : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(1000)]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DimensionId))]
        public ImpactDimension Dimension { get; set; }
        public System.Guid DimensionId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(10000)]
        public string Description { get; set; }
    }
}
