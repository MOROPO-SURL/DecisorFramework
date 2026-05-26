namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ExternalResearcherProjectParticipation : Contract.AbstractResearcherProjectParticipation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResearcherId))]
        public ExternalResearcher Researcher { get ; set ; }
        public System.Guid ResearcherId { get; set; }
    }
}
