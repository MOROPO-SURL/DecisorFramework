namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class PublicationResultExternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PublicationResultExternalResearcherBridge, Entities.PublicationResult, System.Guid, Entities.ExternalResearcher, System.Guid>
{
    public PublicationResultExternalResearcherBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.ExternalResearcherBridges;
    }
}