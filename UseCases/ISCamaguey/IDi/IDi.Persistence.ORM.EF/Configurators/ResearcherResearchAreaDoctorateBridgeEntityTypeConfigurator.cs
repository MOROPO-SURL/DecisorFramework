namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ResearcherResearchAreaDoctorateBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ResearcherResearchAreaDoctorateBridge, Entities.Contract.AbstractResearcher, System.Guid, Entities.ResearchArea, System.Guid>
    {
        public ResearcherResearchAreaDoctorateBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaDoctorateBridges;
        }
    }
}
