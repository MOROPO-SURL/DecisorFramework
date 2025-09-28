namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ThesisResultResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ThesisResultResearcherBridge, Entities.ThesisResult, System.Guid, Entities.Contract.AbstractResearcher, System.Guid>
    {
        public ThesisResultResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearcherBridges;
        }
    }
}
