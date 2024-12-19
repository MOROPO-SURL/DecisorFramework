namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ServiceValuePropositionRate : Contract.AbstractValuePropositionRate
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropositionId))]
        public ServiceValueProposition Proposition { get; set; }
        public System.Guid PropositionId { get; set; }
    }
}
