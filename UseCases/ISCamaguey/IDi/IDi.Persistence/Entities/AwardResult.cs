using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class AwardResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AwardKindId))]
        public AwardKind AwardKind { get; set; } 
        public System.Guid AwardKindId { get; set; }

        public Enumerations.AwardModality AwardModality { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ReceptorId))]
        public Employee Receptor { get; set; }
        public System.Guid ReceptorId { get; set; }
    }
}
