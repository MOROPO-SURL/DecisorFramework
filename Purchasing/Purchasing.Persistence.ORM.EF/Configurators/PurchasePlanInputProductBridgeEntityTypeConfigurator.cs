namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchasePlanInputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchasePlanInputProductBridge, Entities.PurchasePlan, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchasePlanInputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InputProductBridges;
        }
    }
}
