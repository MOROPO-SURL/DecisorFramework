namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderBudgetProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalProviderBudgetProductBridge, Entities.NaturalProviderBudget, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public NaturalProviderBudgetProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductBridges;
        }
    }
}
