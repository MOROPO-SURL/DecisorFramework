namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalProvider : Contract.AbstractNaturalRelationship
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }
    }
}
