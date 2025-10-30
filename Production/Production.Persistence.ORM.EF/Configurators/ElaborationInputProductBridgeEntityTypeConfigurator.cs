namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationInputProductBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationInputProductBridge, Entities.Elaboration, System.Guid, Inventory.Persistence.Entities.Product, System.Guid>
    {
        public ElaborationInputProductBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InputProductBridges;
        }
    }
}
