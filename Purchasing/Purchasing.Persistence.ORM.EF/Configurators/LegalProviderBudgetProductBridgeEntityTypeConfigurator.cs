namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class LegalProviderBudgetProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalProviderBudgetProductBridge, Entities.LegalProviderBudget, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public LegalProviderBudgetProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductBridges;
        }
    }
}

