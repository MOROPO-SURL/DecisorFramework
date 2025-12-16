namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators;

public class ElaborationOutputProductClassificationBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationOutputProductClassificationBridge, Entities.Elaboration, System.Guid, Inventory.Persistence.Entities.Classification, System.Guid>
{
    public ElaborationOutputProductClassificationBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.OutputProductClassificationBridges;
    }
}