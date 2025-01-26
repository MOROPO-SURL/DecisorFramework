namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionProductBridge, Entities.Production, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public ProductionProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProductBridges;
        }
    }
}
