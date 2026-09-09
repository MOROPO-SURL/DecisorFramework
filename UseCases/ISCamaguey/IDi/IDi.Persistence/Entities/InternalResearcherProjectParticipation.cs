namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class InternalResearcherProjectParticipation : Contract.AbstractResearcherProjectParticipation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResearcherId))]
        public InternalResearcher Researcher { get ; set ; }
        public System.Guid ResearcherId { get; set; }
    }
}
