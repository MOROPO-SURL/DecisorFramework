namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderProductSpentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderProductSpentBridge, Entities.PurchaseOrder, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseOrderProductSpentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SpentProductBridges;
        }
    }
}
