namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchasePlanOutputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchasePlanOutputProductBridge, Entities.PurchasePlan, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public PurchasePlanOutputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.OutputProductBridges;
        }
    }
}
