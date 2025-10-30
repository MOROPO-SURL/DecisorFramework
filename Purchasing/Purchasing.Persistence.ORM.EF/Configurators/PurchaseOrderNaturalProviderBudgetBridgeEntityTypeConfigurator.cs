namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderNaturalProviderBudgetBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderNaturalProviderBudgetBridge, Entities.PurchaseOrder, System.Guid, Entities.NaturalProviderBudget, System.Guid>
    {
        public PurchaseOrderNaturalProviderBudgetBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.NaturalProviderBudgetBridges;
        }
    }
}
