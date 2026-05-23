namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectInternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, InternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public InternalResearcher Stern { get ; set ; }

        public int TimeAvailability { get; set; }
    }
}
