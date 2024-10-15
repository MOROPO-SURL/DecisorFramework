namespace MOROPO.Framework.Decisor.Sales.Persistence.Entities
{
    public class NaturalClient : Core.Persistence.Entities.Contract.AbstractNaturalRelationship
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public Core.Persistence.Entities.NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }
    }
}

