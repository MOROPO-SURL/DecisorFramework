namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectSpecificObjective : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid ProjectId { get; set; }
    }
}
