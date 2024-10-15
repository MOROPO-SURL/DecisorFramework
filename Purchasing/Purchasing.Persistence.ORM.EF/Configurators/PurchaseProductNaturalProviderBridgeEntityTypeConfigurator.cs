namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseProductNaturalProviderBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseProductNaturalProviderBridge, Entities.Purchase, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseProductNaturalProviderBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.NaturalProviderProductBridges;
        }
    }
}
