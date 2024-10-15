namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseProductLegalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseProductLegalProviderBridge, Entities.Purchase, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseProductLegalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.LegalProviderProductBridges;
        }
    }
}
