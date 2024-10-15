namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchasePurchaseSpentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchasePurchaseSpentBridge, Entities.Purchase, System.Guid, Entities.PurchaseSpent, System.Guid>
    {
        public PurchasePurchaseSpentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SpentBridges;
        }
    }
}
