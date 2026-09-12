using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class Assessment : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkPlanId))]
        public WorkPlan WorkPlan { get; set; }
        public System.Guid? WorkPlanId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleId))]
        public Contract.AbstractSample Sample { get; set; }
        public System.Guid SampleId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
        public System.Guid DocumentId { get; set; }
    }
}
