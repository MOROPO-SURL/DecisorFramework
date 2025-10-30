namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseRequestProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseRequestProductBridge, Entities.PurchaseRequest, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseRequestProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductBridges;
        }
    }
}
