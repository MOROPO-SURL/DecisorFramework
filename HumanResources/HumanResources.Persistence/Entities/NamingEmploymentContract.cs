namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingEmploymentContract : Contract.AbstractEmploymentContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NamingResolutionId))]
        public NamingResolution Resolution { get; set; }
        public System.Guid NamingResolutionId { get; set; }

        public System.DateTime? InterviewAt { get; set; }

        public string Description { get; set; }
    }
}
