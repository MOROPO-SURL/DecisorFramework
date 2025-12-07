namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, Contract.AbstractResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Contract.AbstractResearcher Stern { get ; set ; }

        public int TimeAvailability { get; set; }
    }
}
