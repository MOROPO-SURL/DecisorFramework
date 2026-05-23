namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class PublicationResultInternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PublicationResultInternalResearcherBridge, Entities.PublicationResult, System.Guid, Entities.InternalResearcher, System.Guid>
{
    public PublicationResultInternalResearcherBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.InternalResearcherBridges;
    }
}