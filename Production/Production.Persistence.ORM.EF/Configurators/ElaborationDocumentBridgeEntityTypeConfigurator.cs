namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators;

public class ElaborationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ElaborationDocumentBridge, Entities.Elaboration, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
{
    public ElaborationDocumentBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.DocumentBridges;
    }
}
