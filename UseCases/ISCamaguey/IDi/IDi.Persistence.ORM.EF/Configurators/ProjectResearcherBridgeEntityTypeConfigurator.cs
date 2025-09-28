namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProjectResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProjectResearcherBridge, Entities.Project, System.Guid, Entities.Contract.AbstractResearcher, System.Guid>
    {
        public ProjectResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearcherBridges;
        }
    }
}
