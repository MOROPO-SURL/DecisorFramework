namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingResolution : Legal.Persistence.Entities.Contract.AbstractResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid? AgreementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid? VacantId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public System.Guid? StaffId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CandidateId))]
        public OcupationCandidate Candidate { get; set; }
        public System.Guid? CandidateId { get; set; }

        public System.DateTime? ConcretedAt { get; set; }
    }
}
