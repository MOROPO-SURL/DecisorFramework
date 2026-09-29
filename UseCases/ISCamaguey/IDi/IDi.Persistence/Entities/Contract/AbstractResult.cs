using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractResult : IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }

        public System.DateTime At {  get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid? ProjectId { get; set; }
    }
}
