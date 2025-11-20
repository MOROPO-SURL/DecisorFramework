namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationOutputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationOutputProductBridge, Entities.Elaboration, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public ElaborationOutputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.OutputProductBridges;
        }
    }
}
