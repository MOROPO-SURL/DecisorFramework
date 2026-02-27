namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingResolution : Contract.AbstractIncorporationResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CandidateId))]
        public OcupationCandidate Candidate { get; set; }
        public System.Guid CandidateId { get; set; }
    }
}