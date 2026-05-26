namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractResearcherProjectParticipation : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid ProjectId { get; set; }

        public int TimeAvailability { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }
    }
}
