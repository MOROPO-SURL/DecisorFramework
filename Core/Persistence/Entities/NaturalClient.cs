namespace MOROPO.Framework.Decisor.Core.Persistence.Entities
{
    public class NaturalClient : Contract.AbstractNaturalRelationship
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }
    }
}

