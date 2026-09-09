namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class ThesisResultInternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ThesisResultInternalResearcherBridge, Entities.ThesisResult, System.Guid, Entities.InternalResearcher, System.Guid>
{
    public ThesisResultInternalResearcherBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.InternalResearcherBridges;
    }
}
