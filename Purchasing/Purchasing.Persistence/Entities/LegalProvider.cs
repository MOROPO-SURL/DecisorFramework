namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class LegalProvider : Core.Persistence.Entities.Contract.AbstractLegalRelationship
    {
        public System.Collections.Generic.List<LegalProviderPurchaseZoneBridge> ZoneBridges { get; set; } = new System.Collections.Generic.List<LegalProviderPurchaseZoneBridge>();
    }
}