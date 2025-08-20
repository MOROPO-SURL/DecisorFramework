namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class AdmitionPropousal : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OcupationCandidateId))]
        public OcupationCandidate OcupationCandidate { get; set; }
        public System.Guid OcupationCandidateId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid AgreementId { get; set; }

        public string Argument { get; set; }
    }
}
