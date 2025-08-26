namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingEmploymentContract : Contract.AbstractEmploymentContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResolutionId))]
        public NamingResolution Resolution { get; set; }
        public long? ResolutionId { get; set; }

        public System.DateTime? InterviewAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid? ResponsibleId { get; set; }

        public string Description { get; set; }
    }
}
