namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class ResearchSample : Contract.AbstractSample
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public IDi.Persistence.Entities.Project Project { get; set; }
        public System.Guid ProjectId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResearcherId))]
        public IDi.Persistence.Entities.Contract.AbstractResearcher Researcher { get; set; }
        public System.Guid ResearcherId { get; set; }
    }
}