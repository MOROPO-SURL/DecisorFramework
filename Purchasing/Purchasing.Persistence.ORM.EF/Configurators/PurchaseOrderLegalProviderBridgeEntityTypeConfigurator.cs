namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderLegalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderLegalProviderBridge, Entities.PurchaseOrder, System.Guid, Commercial.Persistence.Entities.LegalProvider, System.Guid>
    {
        public PurchaseOrderLegalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.LegalProviderBridges;
        }
    }
}
