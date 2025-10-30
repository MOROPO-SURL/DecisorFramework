namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderProductResultBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderProductResultBridge, Entities.PurchaseOrder, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchaseOrderProductResultBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResultProductBridges;
        }
    }
}
