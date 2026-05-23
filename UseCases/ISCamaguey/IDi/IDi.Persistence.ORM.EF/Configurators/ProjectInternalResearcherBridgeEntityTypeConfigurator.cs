namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProjectInternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProjectInternalResearcherBridge, Entities.Project, System.Guid, Entities.InternalResearcher, System.Guid>
    {
        public ProjectInternalResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InternalResearcherBridges;
        }
    }
}
