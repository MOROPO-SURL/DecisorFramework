namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class AdmitionEmploymentContract : Contract.AbstractEmploymentContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AdmitionPropousalId))]
        public AdmitionPropousal AdmitionPropousal { get; set; }
        public System.Guid? AdmitionPropousalId { get; set; }
    }
}
