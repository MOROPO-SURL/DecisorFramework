namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public class ThesisResultExternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ThesisResultExternalResearcherBridge, Entities.ThesisResult, System.Guid, Entities.ExternalResearcher, System.Guid>
{
    public ThesisResultExternalResearcherBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.ExternalResearcherBridges;
    }
}
