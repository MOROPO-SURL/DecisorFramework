namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProjectParticipatingOrganizationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProjectParticipatingOrganizationBridge, Entities.Project, System.Guid, Entities.ParticipatingOrganization, System.Guid>
    {
        public ProjectParticipatingOrganizationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ParticipatingOrganizationBridges;
        }
    }
}
