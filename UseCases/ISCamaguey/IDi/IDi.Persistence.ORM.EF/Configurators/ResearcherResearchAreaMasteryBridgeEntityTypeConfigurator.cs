namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ResearcherResearchAreaMasteryBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ResearcherResearchAreaMasteryBridge, Entities.Contract.AbstractResearcher, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public ResearcherResearchAreaMasteryBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaMasteryBridges;
        }
    }
}
