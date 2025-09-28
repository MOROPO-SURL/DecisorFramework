namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectParticipatingOrganizationBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, ParticipatingOrganization, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public ParticipatingOrganization Stern { get ; set ; }
    }
}
