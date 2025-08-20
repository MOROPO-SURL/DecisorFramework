namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkPositionResponsability : Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPositionId))]
        public WorkPosition WorkPosition { get; set; }
        public System.Guid WorkPositionId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
