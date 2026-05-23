namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProjectExternalResearcherBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProjectExternalResearcherBridge, Entities.Project, System.Guid, Entities.ExternalResearcher, System.Guid>
    {
        public ProjectExternalResearcherBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ExternalResearcherBridges;
        }
    }
}
