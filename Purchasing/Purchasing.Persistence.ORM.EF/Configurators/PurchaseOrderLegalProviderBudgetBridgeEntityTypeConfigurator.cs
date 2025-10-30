namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseOrderLegalProviderBudgetBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseOrderLegalProviderBudgetBridge, Entities.PurchaseOrder, System.Guid, Entities.LegalProviderBudget, System.Guid>
    {
        public PurchaseOrderLegalProviderBudgetBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.LegalProviderBudgetBridges;
        }
    }
}
