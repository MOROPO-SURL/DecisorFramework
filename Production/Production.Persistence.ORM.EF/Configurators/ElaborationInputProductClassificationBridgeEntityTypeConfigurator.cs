namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ElaborationInputProductClassificationBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationInputProductClassificationBridge, Entities.Elaboration, System.Guid, Inventory.Persistence.Entities.Classification, System.Guid>
    {
        public ElaborationInputProductClassificationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InputProductClassificationBridges;
        }
    }
}
