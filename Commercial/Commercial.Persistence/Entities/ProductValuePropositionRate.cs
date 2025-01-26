namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class ProductValuePropositionRate : Contract.AbstractValuePropositionRate
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropositionId))]
        public ProductValueProposition Proposition { get; set; }
        public System.Guid PropositionId { get; set; }
    }
}
