namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseReceptionProductWeightBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseReceptionProductWeightBridge, Entities.PurchaseReception, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseReceptionProductWeightBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductWeightBridges;
        }
    }
}
