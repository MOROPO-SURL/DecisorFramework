namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class NaturalProvider : Core.Persistence.Entities.Contract.AbstractNaturalRelationship
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BusinessKindId))]
        public Core.Persistence.Entities.NaturalBusinessKind BusinessKind { get; set; }
        public System.Guid BusinessKindId { get; set; }

        public System.Collections.Generic.List<NaturalProviderPurchaseZoneBridge> ZoneBridges { get; set; } = new System.Collections.Generic.List<NaturalProviderPurchaseZoneBridge>();
    }
}
